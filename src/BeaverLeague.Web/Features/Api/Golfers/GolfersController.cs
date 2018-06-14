//using System.Threading.Tasks;
//using BeaverLeague.Web.Security;
//using BeaverLeague.Web.Services;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace BeaverLeague.Web.Features.Api.Golfers
//{
//    [UserIsAdmin]
//    [Route("api/admin/[controller]")]
//    public class GolfersController : Controller
//    {    
//        public GolfersController()
//        {
            
//        }

//        [HttpGet]
//        public IActionResult Get()
//        {
//            //var golfers =
//            //    _db.Golfers
//            //          .Where(g => !query.IsActive || query.IsActive && g.IsActive)
//            //          .OrderBy(g => g.LastName)
//            //          .Select(g => new GolferSummary
//            //          {
//            //              Id = g.Id,
//            //              FirstName = g.FirstName,
//            //              Handicap = g.Handicap,
//            //              IsActive = g.IsActive,
//            //              IsAdmin = g.IsAdmin,
//            //              LastName = g.LastName,
//            //              MembershipId = g.MembershipId
//            //          })
//            //          .ToList();
//            return Content("");
//        }

//        [HttpGet]
//        [Route("active")]
//        public IActionResult GetActive()
//        {
//            return Content("");
//        }

//        [HttpPost]
//        [Route("{id}/activeflag")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> PostActiveFlag([FromRoute] int id, [FromBody] UpdateActiveFlagCommand command)
//        {
//            if (ModelState.IsValid)
//            {
//                //var result = new UpdateActiveFlagResult();
//                //var golfer = await _db.Golfers.FirstOrDefaultAsync(g => g.Id == command.Id);
//                //if (golfer != null)
//                //{
//                //    golfer.IsActive = command.Value;
//                //    await _db.SaveChangesAsync();
//                //    result.Golfer = golfer;
//                //}
//            }
//            return BadRequest(ModelState);
//        }
//    }
//}
