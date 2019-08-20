using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BeaverLeague.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GolfersController : ControllerBase
    {
        private readonly LeagueDbContext db;

        public GolfersController(LeagueDbContext db)
        {
            this.db = db;
        }

        public ActionResult<List<Golfer>> Get()
        {
            return db.Golfers.ToList();
        }
    }
}