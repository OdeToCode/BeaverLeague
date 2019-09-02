using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Tests.Helpers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BeaverLeague.Tests.Pages.Admin.Seasons
{
    public class ManageTests : IClassFixture<BeaverLeagueWebFactory>
    {
        private readonly BeaverLeagueWebFactory factory;

        public ManageTests(BeaverLeagueWebFactory factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task DisplaysCurrentSeasonInformation()
        {
            using var scope = factory.Services.GetScopedDbContext<LeagueDbContext>();
            var db = scope.Db;

            var season1 = new Season() { Name = "2019" };
            var season2 = new Season() { Name = "2020" };

            db.Add(season1);
            db.SaveChanges();

            db.Add(season2);
            db.SaveChanges();

            var client = factory.CreateClient();
            var response = await client.GetAsync("/Admin/Seasons/Manage");
            var document = await response.GetDocumentAsync();
            var seasonName = document.QuerySelector("#current-season")?.TextContent;
            var weeks = document.QuerySelectorAll("#seasons tbody tr");

            Assert.Equal(2, weeks.Length);
            Assert.Equal("2020", seasonName);

        }
    }
}
