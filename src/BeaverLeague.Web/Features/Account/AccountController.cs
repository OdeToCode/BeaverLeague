using BeaverLeague.Data.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeaverLeague.Web.Features.Account
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {

        public AccountController(GolferManager userManager, GolferSignInManager signInManager)
        {
            
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(object o)
        {
            return View();
        }

    }
}
