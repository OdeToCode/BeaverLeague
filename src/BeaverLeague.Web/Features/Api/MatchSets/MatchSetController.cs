using System.Threading.Tasks;
using BeaverLeague.Web.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeaverLeague.Web.Features.Api.MatchSets
{
    [UserIsAdmin]
    [Route("api/[controller]")]
    public class MatchSetController
    {
        private readonly IMediator _mediator;

        public MatchSetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new MatchSetQuery {MatchSetId = id};
            var result = await _mediator.Send(query);
            return new ObjectResult(result);
        }
    }
}