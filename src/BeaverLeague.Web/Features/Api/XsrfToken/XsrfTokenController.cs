using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;

namespace BeaverLeague.Web.Features.Api.XsrfToken
{
    [Route("api/[controller]")]
    public class XsrfTokenController : Controller
    {
        private readonly IAntiforgery _antiforgery;

        public XsrfTokenController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);

            return new ObjectResult(new {
                token = tokens.RequestToken,
                tokenName = tokens.HeaderName    
            });
        }    
    }
}