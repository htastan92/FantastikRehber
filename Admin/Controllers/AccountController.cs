using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Dtos;
using Admin.Dtos.MemberDtos;
using Business.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using IdentityResult = Microsoft.AspNetCore.Identity.IdentityResult;

namespace Admin.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<Member> _userManager;
        private Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Member> _signInManager;
        private readonly IEmailSender _emailSender;

        public AccountController(Microsoft.AspNetCore.Identity.UserManager<Member> userManager, Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager, SignInManager<Member> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var accountPage = new MemberListDto()
            {
                Members = _userManager.Users.ToList(),
                Roles = _roleManager.Roles.ToList()
            };
            return View(accountPage);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(MemberRegisterDto userRegisterDto)
        {
            if (ModelState.IsValid)
            {

                var member = new Member()
                {
                    Email = userRegisterDto.Email,
                    UserName = userRegisterDto.UserName,
                    FirstName = userRegisterDto.FirstName,
                    LastName = userRegisterDto.LastName,
                };
                var result = await _userManager.CreateAsync(member, userRegisterDto.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(member, "Standart Kullanıcı");
                    return RedirectToAction("Login");
                }
                else
                {
                    result.Errors.ToList().ForEach(a => ModelState.AddModelError("", a.Description));
                    return Content("Bir hata oluştu lütfen tekrar deneyin");
                }
            }
            return View(userRegisterDto);
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl, string firstName, string lastName)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Account");

            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(MemberLoginDto member)
        {
            if (!ModelState.IsValid)
                return View(member);

            var result = await _signInManager.PasswordSignInAsync(member.UserName, member.Password, false, false);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(member.ReturnUrl))
                    return Redirect(member.ReturnUrl);
                return RedirectToAction("Index");
            }
            else if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Üst üste yanlış kullanıcı adı veya şifre girdiniz.");
            }
            else
                ModelState.AddModelError("", "Yanlış kullanıcı adı veya şifre girdiniz.");

            return View(member);
        }

        public async Task<IActionResult> EditUser(string id)
        {
            var result = await _userManager.FindByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(Member editedUser)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(editedUser.Id);
                user.UserName = editedUser.UserName;
                user.Email = editedUser.Email;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    result.Errors.ToList().ForEach(a=>ModelState.AddModelError("",a.Description));
                }
            }

            return View(editedUser);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var currentUserId = User.Identity.GetUserId();
            if (user.Id != currentUserId)
            {
                await _userManager.DeleteAsync(user);
                return RedirectToAction("Index");
            }
            else
            {
                await _userManager.DeleteAsync(user);
                Logout();
                return RedirectToAction("Login");
            }
        }
        public IActionResult ChangePassword(string userId)
        {
            ViewBag.UserId = userId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(MemberPasswordDto password)
        {
            if (password.UserId == null)
            {
                if (!ModelState.IsValid)
                    return View(password);

                var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());
                var check = await _signInManager.CheckPasswordSignInAsync(user, password.OldPassword, false);
                if (check.Succeeded)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password.NewPassword);
                    var result = await _userManager.UpdateAsync(user);

                    Logout();

                    if (result.Succeeded)
                        return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            else
            {
                if (!ModelState.IsValid)
                    return View(password);

                var user = await _userManager.FindByIdAsync(password.UserId);
                var checkPassword = await _signInManager.CheckPasswordSignInAsync(user, password.OldPassword, false);

                if (checkPassword.Succeeded)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password.NewPassword);
                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                        return RedirectToAction("Index");
                }
            }

            return View(password);
        }
        [AllowAnonymous]
        
        public IActionResult ForgotPassword()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(MemberPasswordDto passwordDto)
        {
            var user = await _userManager.FindByEmailAsync(passwordDto.Email);
            if (user != null)
            {
                var passwordCode = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, passwordCode = passwordCode }, Request.Scheme);

                await _emailSender.SendEmailAsync(user.Email, "Reset Password",
                    "Please reset your password by clicking here : <a href=\" " + callbackUrl + "\">link</a>",user.FirstName,user.LastName);
                ViewBag.callbackUrl = callbackUrl;
                return View("Login");
            }

            return View(passwordDto);
        }

        [AllowAnonymous]
        public IActionResult ResetPassword(string userId, string passwordCode)
        {
            if (userId != null && passwordCode != null) 
            {
                var passwordDto = new ResetPasswordDto()
                {
                    UserId = userId,
                    PasswordCode = passwordCode
                };
                return View(passwordDto);
            }

            return Content("Bir hata oluştu lütfen tekrar deneyiniz");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto passwordDto)
        {
            if (!ModelState.IsValid)
                return View(passwordDto);

            if (passwordDto.NewPassword != null)
            {
                var user = await _userManager.FindByIdAsync(passwordDto.UserId);
                var result = await _userManager.ResetPasswordAsync(user, passwordDto.PasswordCode, passwordDto.NewPassword);
                if (result.Succeeded)
                    return RedirectToAction("Login");

            }

            return Content("Bir hata oluştu lütfen tekrar deneyiniz.");

        }

        public IActionResult NewRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewRole(RoleDto roleDto,string id)
        {
            IdentityResult result = null;
            if (id!=null)
            {
                var role = await _roleManager.FindByIdAsync(id);
                role.Name = roleDto.Name;
                result = await _roleManager.UpdateAsync(role);
            }
            else
            {
                 result = await _roleManager.CreateAsync(new IdentityRole{Name = roleDto.Name});
            }

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteRole(RoleDto roleDto)
        {
            var role = await _roleManager.FindByIdAsync(roleDto.Id);

            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("Silme işleminde bir hata oluştu.");
                }
            }

            return Content("Böyle bir role sahip değiliz");
        }

        public async Task<IActionResult> EditRole(RoleDto roleDto)
        {
            var role = await _roleManager.FindByIdAsync(roleDto.Id);
            if (role != null)
                return View(roleDto);
            return Content("Böyle bir rol bulunmamaktadır");
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(IdentityRole role)
        {
            var roleUpdate = await _roleManager.FindByIdAsync(role.Id);
            if (roleUpdate != null)
            {
                await _roleManager.SetRoleNameAsync(roleUpdate, role.Name);
                var result = await _roleManager.UpdateAsync(roleUpdate);

                if (result.Succeeded)
                    return RedirectToAction("Index");
            }

            return Content("Böyle bir rol bulunmamaktadır");
        }

        public async Task<IActionResult> RoleAssign(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            List<IdentityRole> allRoles = _roleManager.Roles.ToList();
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            List<RoleAssignViewModel> assignRoles = new List<RoleAssignViewModel>();
            allRoles.ForEach(role => assignRoles.Add(new RoleAssignViewModel
            {
                HasAssign = userRoles.Contains(role.Name),
                RoleId = role.Id,
                RoleName = role.Name
            }));

            return View(assignRoles);
        }
        [HttpPost]
        public async Task<ActionResult> RoleAssign(List<RoleAssignViewModel> modelList, string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            foreach (RoleAssignViewModel role in modelList)
            {
                if (role.HasAssign)
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                else
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
            }
            return RedirectToAction("Index", "Account");
        }
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}