using System.Threading.Tasks;
using BeaverLeague.Web.Security;
using BeaverLeague.Web.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeaverLeague.Web.Features.Admin.ManageGolfers
{
    [UserIsAdmin]
    [Route("admin/[controller]/[action]")]
    public class ManageGolfersController : Controller
    {
        private readonly IMediator _mediatr;

        public ManageGolfersController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        public IActionResult List()
        {
            return View("List");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm]object o)
        {
            return View();
        }
    }
}
