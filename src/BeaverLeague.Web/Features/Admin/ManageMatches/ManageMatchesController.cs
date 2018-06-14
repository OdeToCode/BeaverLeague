//using System.Threading.Tasks;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace BeaverLeague.Web.Features.Admin.ManageMatches
//{

//    // /get

    

//    [Route("admin/[controller]/[action]")]
//    public class ManageMatchesController : Controller
//    {
//        private readonly IMediator _mediator;

//        public ManageMatchesController(IMediator mediator)
//        {
//            _mediator = mediator;
//        }

//        [Route("{seasonId}")]
//        [HttpPost, ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(int seasonId)
//        {
            


//            var command = new CreateMatchSetCommand {SeasonId = seasonId};
//            var result = await _mediator.Send(command);
//            return RedirectToAction("Edit", new {matchSetId = result.MatchSet.Id });
//        }

//        [Route("{matchSetId}")]
//        public IActionResult Edit(int matchSetId)
//        {
//            return View("Edit", new { matchSetId });
//        }
//    }
//}