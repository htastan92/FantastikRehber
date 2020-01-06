using System.Linq;
using System.Threading.Tasks;
using Admin.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;

namespace Admin.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<Member> _userManager;
        private Microsoft.AspNetCore.Identity.RoleManager<MemberRole> _roleManager;
        private readonly SignInManager<Member> _signInManager;
        
        

        public AccountController(Microsoft.AspNetCore.Identity.UserManager<Member> userManager, Microsoft.AspNetCore.Identity.RoleManager<MemberRole> roleManager, SignInManager<Member> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var userList = new MemberListDto()
            {
                Members = _userManager.Users.ToList()
            };
            return View(userList);
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
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
                    Password = userRegisterDto.Password
                };
                var result = await _userManager.CreateAsync(member, userRegisterDto.Password);

                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    result.Errors.ToList().ForEach(a => ModelState.AddModelError("", a.Description));
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

        [AllowAnonymous]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Login");
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

        
    }
    

}