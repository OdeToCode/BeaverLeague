using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BeaverLeague.Data;
using BeaverLeague.Web.Security;
using BeaverLeague.Web.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeaverLeague.Web.Messaging
{
    public class LoginUserCommand : IAsyncRequest<SignInResult>
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
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
