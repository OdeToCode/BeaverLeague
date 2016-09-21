using System.Threading.Tasks;
using BeaverLeague.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BeaverLeague.Web.Messaging
{
    public class LoginUserCommand : IAsyncRequest<LoginUserResult>
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class LoginUserCommandHandler : IAsyncRequestHandler<LoginUserCommand, LoginUserResult>
    {
        private readonly UserManager<Golfer> _userManager;
        private readonly SignInManager<Golfer> _signInManager;

        public LoginUserCommandHandler(UserManager<Golfer> userManager, SignInManager<Golfer> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginUserResult> Handle(LoginUserCommand message)
        {
            var result = new LoginUserResult();
            var golfer = await _userManager.FindByEmailAsync(message.EmailAddress);
            var loginResult = await _signInManager.PasswordSignInAsync(golfer, message.Password, message.RememberMe, false);
            if (loginResult.Succeeded)
            {
                result.Success = true;
            }
            return result;
        }
    }

    public class LoginUserResult
    {
        public LoginUserResult()
        {
            Success = false;
        }

        public bool Success { get; set; }
    }
}
