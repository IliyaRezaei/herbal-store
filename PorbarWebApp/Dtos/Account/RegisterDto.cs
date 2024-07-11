using System.ComponentModel.DataAnnotations;

namespace PorbarWebApp.Dtos.Account
{
    public class RegisterDto
    {
        [Display(Name = "آدرس ایمیل")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "رمز ورود")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "تایید رمز ورود")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
