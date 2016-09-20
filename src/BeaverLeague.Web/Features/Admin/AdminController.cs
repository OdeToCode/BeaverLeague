using BeaverLeague.Web.Security;
using Microsoft.AspNetCore.Mvc;

namespace BeaverLeague.Web.Features.Admin
{
    [UserIsAdmin]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
    }
}
