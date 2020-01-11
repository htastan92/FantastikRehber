using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Admin.Dtos.MemberDtos
{
    public class MemberRegisterDto
    {
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MinLength(5)][MaxLength(15)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MaxLength(20)][MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MaxLength(15)]
        [MinLength(2)]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Şifreler eşleşmiyor")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MinLength(2)]
        [MaxLength(15)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MinLength(2)]
        [MaxLength(15)]
        public string LastName { get; set; }
        public IList<IFormFile> Photos { get; set; }
    }
}
