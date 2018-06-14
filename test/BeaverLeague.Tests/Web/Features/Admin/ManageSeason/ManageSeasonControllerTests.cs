//using System.Threading.Tasks;
//using BeaverLeague.Core.Models;
//using BeaverLeague.Data;
//using BeaverLeague.Tests.Data;
//using BeaverLeague.Web.Features.Admin.ManageSeason;
//using BeaverLeague.Web.Messaging;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Xunit;
//using Microsoft.EntityFrameworkCore;

//namespace BeaverLeague.Tests.Web.Features.Admin.ManageSeason
//{
//    public class ManageSeasonControllerTests
//    {
//        public ManageSeasonControllerTests()
//        {
//            LeagueDbInstance db = new LeagueDbInstance(nameof(ManageSeasonControllerTests));
//            _testContext = db.NewContext();
//            _verifyContext = db.NewContext();

//            _mediator = new Mediator(null);
//        }

//        [Fact]
//        public async Task CanCreateSeason()
//        {
//            var controller = new ManageSeasonController(_mediator);
//            var inputModel = new CreateSeasonCommand() {Name = "2017"};

//            var result = await controller.Create(inputModel);

//            var verifySeason = await _verifyContext.Seasons.SingleOrDefaultAsync(s => s.Name == "2017");
//            Assert.IsType<RedirectToActionResult>(result);
//            Assert.Equal("2017", verifySeason.Name);
//        }

//        [Fact]
//        public async Task CanFailOnDuplicateSeasonNames()
//        {
//            var controller = new ManageSeasonController(_mediator);
//            var inputModel = new CreateSeasonCommand { Name = "2017" };

//            _testContext.Seasons.Add(new Season {Name = "2017"});
//            _testContext.SaveChanges();
//            var result = await controller.Create(inputModel) as ViewResult;

//            Assert.NotNull(result);
//            Assert.Equal(1, result.ViewData.ModelState.ErrorCount);
//        }

//        private readonly IMediator _mediator;
//        private readonly LeagueDb _testContext;
//        private readonly LeagueDb _verifyContext;
//    }
//}
