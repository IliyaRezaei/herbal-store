using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PorbarWebApp.Dtos.Account
{
    public class LoginDto
    {
        [Required]
        [DisplayName("آدرس ایمیل")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("رمز ورود")]
        public string Password { get; set; }
    }
}
