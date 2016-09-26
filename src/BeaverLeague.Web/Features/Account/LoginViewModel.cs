using System.ComponentModel.DataAnnotations;

namespace BeaverLeague.Web.Features.Account
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            RememberMe = true;
        }

        [Required]
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name ="Remember Me?")]
        public bool RememberMe { get; set; }
    }
}
