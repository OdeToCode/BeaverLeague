using System.Threading.Tasks;
using BeaverLeague.Web.Messaging;
using BeaverLeague.Web.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeaverLeague.Web.Features.Admin.ManageSeason
{
    [Route("[controller]/[action]")]
    public class ManageSeasonController : Controller
    {
        private readonly IMediator _mediator;

        public ManageSeasonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> CurrentSeason()
        {
            var query = new CurrentSeasonSummaryQuery();
            var model = await _mediator.SendAsync(query);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSeasonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateSeasonCommand(model);
                var result = await _mediator.SendAsync(command);
                if (result.Success)
                {
                    return RedirectToAction(nameof(CurrentSeason));
                }
                ModelState.AddModelErrors(result.Errors);
            }
            return View(model);
        }
    }
}
