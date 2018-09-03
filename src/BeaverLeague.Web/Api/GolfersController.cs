using BeaverLeague.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BeaverLeague.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GolfersController : ControllerBase
    {
        public ActionResult<List<Golfer>> Get()
        {
            return new List<Golfer>()
            {
                new Golfer  { Id= 1, FirstName="Scott", LastName="Allen"},
                new Golfer { Id = 2, FirstName="Blarg", LastName="BlargFace"}
            };
        }
    }
}