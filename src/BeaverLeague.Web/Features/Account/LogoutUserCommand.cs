using System.Threading;
using System.Threading.Tasks;
using BeaverLeague.Web.Security;
using MediatR;

namespace BeaverLeague.Web.Messaging
{
    public class LogoutUserCommand : IRequest<bool>
    {
    }

    public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand, bool>
    {
        private readonly SignInManager _signInManager;

        public LogoutUserCommandHandler(SignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Handle(LogoutUserCommand message, CancellationToken cancel)
        {
            return await _signInManager.SignOutGolferAsync();
        }
    }
}
