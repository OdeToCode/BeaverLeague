using System.Threading.Tasks;
using BeaverLeague.Web.Messaging.Golfers;
using BeaverLeague.Web.Security;
using BeaverLeague.Web.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeaverLeague.Web.Features.Api.Golfers
{
    [UserIsAdmin]
    [Route("api/[controller]")]
    public class GolfersController : Controller
    {
        private readonly IMediator _mediator;

        public GolfersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var query = new GolfersQuery();
            var model = _mediator.Send(query);
            return new ObjectResult(model);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("active")]
        public IActionResult GetActive()
        {
            var query = new GolfersQuery() {IsActive = true};
            var model = _mediator.Send(query);
            return new ObjectResult(model);
        }

        [HttpPost]
        [Route("{id}/activeflag")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostActiveFlag([FromRoute] int id, [FromBody] UpdateActiveFlagCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.SendAsync(command);
                if (result.Success)
                {
                    return Ok(result.Golfer);
                }
                ModelState.AddModelErrors(result.Errors);
            }
            return BadRequest(ModelState);
        }
    }
}
