using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Dtos
{
    public class MemberLoginDto
    {
        [Required(ErrorMessage = "Kullanıcı Adı Girmediniz.")]
        [DisplayName("UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Parola Girmediniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
