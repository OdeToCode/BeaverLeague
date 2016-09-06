using Microsoft.AspNetCore.Mvc;

namespace BeaverLeague.Web.Features.Admin
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
    }
}
