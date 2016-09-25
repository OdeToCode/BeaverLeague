using Microsoft.AspNetCore.Http;

namespace BeaverLeague.Tests.Web.Features.Account
{
    public class HttpContextWithAuthentication : IHttpContextAccessor
    {
        public HttpContextWithAuthentication()
        {            
            HttpContext = new DefaultHttpContext();            
        }

        public HttpContext HttpContext { get; set; }
    }
}
