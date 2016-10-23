using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BeaverLeague.Web.Security;
using MediatR;

namespace BeaverLeague.Web.Features.Account
{
    public class LoginUserCommand : IAsyncRequest<SignInResult>
    {
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }

    public class LoginUserCommandHandler : IAsyncRequestHandler<LoginUserCommand, SignInResult>
    {
        private readonly SignInManager _signInManager;

        public LoginUserCommandHandler(SignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> Handle(LoginUserCommand command)
        {
            var result = await _signInManager.SignInGolferAsync(
                command.EmailAddress,
                command.Password,
                command.RememberMe);
            return result;
        }
    }
}
