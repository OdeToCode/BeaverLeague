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
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new LoginUserCommand(model);
                var result = await _mediatr.SendAsync(command);
                if (result.Success)
                {
                    return Redirect("/");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            var command = new LogoutUserCommand();
            await _mediatr.SendAsync(command);
            return Redirect("~/");
        }

        public IActionResult AccessDenied()
        {
            return View();
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
