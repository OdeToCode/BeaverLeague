using BeaverLeague.Core.Models;
using BeaverLeague.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BeaverLeague.Tests.Pages.Admin.Weeks
{
    public class CreateTests : IClassFixture<BeaverLeagueWebFactory>
    {
        private readonly BeaverLeagueWebFactory factory;

        public CreateTests(BeaverLeagueWebFactory factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task CanCreateNewMatchSet()
        {
            var client = factory.CreateClient();
            var emptyForm = await client.GetAsync("/Admin/Seasons/1/Weeks/Create");
            var formDocument = await emptyForm.GetDocumentAsync();

            var season = new Season();
            //var matchSet = season.AddWeek();
            //var matchSet = new MatchSet()
            //{
            //    Id = 1,
            //    Date = new DateTime(2019, 9, 4),
            //     SeasonId = 1
            //}

            //var formPost = await client.SendFormAsync(formDocument, "Golfer", golfer);
            //var postDocument = await formPost.GetDocumentAsync();

            //using var scope = factory.Services.GetScopedDbContext<LeagueDbContext>();
            //Assert.Single(scope.Db.Golfers);
        }
    }
}
