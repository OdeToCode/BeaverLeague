using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features.Authentication;

namespace BeaverLeague.Tests.Data.Identity
{
    class FakeAuthenticationHandler : IAuthenticationHandler
    {
        public void GetDescriptions(DescribeSchemesContext context)
        {
            throw new NotImplementedException();
        }

        public Task AuthenticateAsync(AuthenticateContext context)
        {
            context.NotAuthenticated();
            return Task.FromResult(0);
        }

        public Task ChallengeAsync(ChallengeContext context)
        {
            throw new NotImplementedException();
        }

        public Task SignInAsync(SignInContext context)
        {
            context.Accept();
            return Task.FromResult(0);
        }

        public Task SignOutAsync(SignOutContext context)
        {
            throw new NotImplementedException();
        }
    }
}