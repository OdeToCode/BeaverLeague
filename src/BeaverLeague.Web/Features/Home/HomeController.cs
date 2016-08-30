using Microsoft.AspNetCore.Mvc;

namespace BeaverLeague.Web.Features.Home
{
    [Route("[controller]/[action]"), Route("")]
    public class HomeController : Controller
    {
        public ViewResult Home()
        {
            return View();
        }
    }
}
