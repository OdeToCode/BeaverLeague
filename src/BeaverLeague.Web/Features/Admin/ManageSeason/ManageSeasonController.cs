using System.Threading.Tasks;
using BeaverLeague.Web.Messaging;
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
        public IActionResult Create(CreateSeasonViewModel model)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View(model);
        }
    }
}
