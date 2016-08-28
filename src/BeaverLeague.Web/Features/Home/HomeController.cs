using Microsoft.AspNetCore.Mvc;

namespace BeaverLeague.Web.Features.Home
{
    [Route("[controller]/[action]"), Route("")]
    public class HomeController
    {
        [Route("")]
        public string Dashboard()
        {
            return "Hello!";
        }
    }
}
