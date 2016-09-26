using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.Features.Authentication;

namespace BeaverLeague.Tests.Web.Features.Account
{
    public class HttpContextWithAuthentication : IHttpContextAccessor
    {
        public HttpContextWithAuthentication()
        {
            var featureCollection = new FeatureCollection();
            featureCollection.Set<IHttpAuthenticationFeature>(new TestHttpAuthenticationFeature());
            HttpContext = new DefaultHttpContext(featureCollection);
        }

        public HttpContext HttpContext { get; set; }
    }

    public class TestHttpAuthenticationFeature : IHttpAuthenticationFeature
    {
        public TestHttpAuthenticationFeature()
        {
            Handler = new TestCookieAuthenticationHandler();
        }

        public ClaimsPrincipal User { get; set; }
        public IAuthenticationHandler Handler { get; set; }
    }

    public class TestCookieAuthenticationHandler : IAuthenticationHandler
    {
        public void GetDescriptions(DescribeSchemesContext context)
        {
            
        }

        public Task AuthenticateAsync(AuthenticateContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task ChallengeAsync(ChallengeContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task SignInAsync(SignInContext context)
        {
            context.Accept();
            return Task.FromResult(0);
        }

        public Task SignOutAsync(SignOutContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
