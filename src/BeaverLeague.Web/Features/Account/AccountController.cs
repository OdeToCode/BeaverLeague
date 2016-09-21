using System.Threading.Tasks;
using BeaverLeague.Web.Messaging;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeaverLeague.Web.Features.Account
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IMediator _mediatr;

        public AccountController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new LoginUserCommand();
                var result = await _mediatr.SendAsync(command);
                return Content(result.Success.ToString());
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(object o)
        {
            return View();
        }

    }
}
