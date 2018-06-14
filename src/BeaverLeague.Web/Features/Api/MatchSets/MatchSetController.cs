using System.Threading.Tasks;
using BeaverLeague.Web.Security;
using Microsoft.AspNetCore.Mvc;

namespace BeaverLeague.Web.Features.Api.MatchSets
{
    [UserIsAdmin]
    [Route("api/[controller]")]
    public class MatchSetController : Controller
    {
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Content("foo");
        }
    }
}