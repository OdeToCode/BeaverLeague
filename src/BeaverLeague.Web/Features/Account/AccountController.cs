using System.Threading.Tasks;
using BeaverLeague.Web.Messaging;
using BeaverLeague.Web.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
            var model = new LoginUserCommand();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediatr.Send(command);
                if (result.Success)
                {
                    return Redirect("/");
                }
                ModelState.AddModelErrors(result.Errors);
            }
            return View(command);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var command = new LogoutUserCommand();
            await _mediatr.Send(command);
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
