using System.Threading.Tasks;
using BeaverLeague.Web.Security;
using MediatR;

namespace BeaverLeague.Web.Messaging
{
    public class LogoutUserCommand : IAsyncRequest<bool>
    {
    }

    public class LogoutUserCommandHandler : IAsyncRequestHandler<LogoutUserCommand, bool>
    {
        private readonly SignInManager _signInManager;

        public LogoutUserCommandHandler(SignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Handle(LogoutUserCommand message)
        {
            return await _signInManager.SignOutGolferAsync();
        }
    }
}
