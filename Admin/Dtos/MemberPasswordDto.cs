using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Dtos
{
    public class MemberPasswordDto
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [Compare("NewPassword",ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string PasswordCode { get; set; }
    }
}
