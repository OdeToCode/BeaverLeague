using System.Threading.Tasks;
using BeaverLeague.Web.Features.Account;
using BeaverLeague.Web.Security;
using MediatR;

namespace BeaverLeague.Web.Messaging
{
    public class LoginUserCommand : IAsyncRequest<SignInResult>
    {
        public LoginUserCommand(LoginViewModel model)
        {
            EmailAddress = model.EmailAddress;
            Password = model.Password;
            RememberMe = model.RememberMe;
        }

        public LoginUserCommand(string emailAddress, string password, bool rememberMe)
        {
            EmailAddress = emailAddress;
            Password = password;
            RememberMe = rememberMe;
        }

        public string EmailAddress { get; protected set; }
        public string Password { get; protected set; }
        public bool RememberMe { get; protected set; }
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
