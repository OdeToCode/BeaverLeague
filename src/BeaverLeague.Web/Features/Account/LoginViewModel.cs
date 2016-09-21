using System.ComponentModel.DataAnnotations;

namespace BeaverLeague.Web.Features.Account
{
    public class LoginViewModel
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public bool RememberMe { get; set; }
    }
}
