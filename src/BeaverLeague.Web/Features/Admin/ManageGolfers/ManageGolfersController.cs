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

        public IActionResult GetAllGolfers()
        {
            var query = new AllGolfersQuery();
            var model = _mediatr.Send(query);
            return new ObjectResult(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGolferActiveFlag([FromBody] UpdateActiveFlagCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediatr.SendAsync(command);
                if (result.Success)
                {
                    return Ok(result.Golfer);
                }
                ModelState.AddModelErrors(result.Errors);
            }            
            return BadRequest(ModelState);
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
