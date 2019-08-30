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

            var season = new Season("2020");
            var set1 = season.AddWeek(new DateTime(2020, 6, 1));
            var golfer1 = new Golfer { FirstName = "Scott" };
            var golfer2 = new Golfer { FirstName = "Roberto" };
            set1.AddResult(golfer1, 39, 10, true, golfer2, 44, 1, true);

            var set2 = season.AddWeek(new DateTime(2020, 6, 8));
            set2.AddResult(golfer1, 40, 10, true, golfer2, 44, 1, false);

            db.Add(season);
            db.SaveChanges();

            var client = factory.CreateClient();
            var response = await client.GetAsync("/Admin/Seasons/Manage");
            var document = await response.GetDocumentAsync();
            var seasonName = document.QuerySelector("#current-season")?.TextContent;
            var weeks = document.QuerySelectorAll("#weeks tbody tr");

            Assert.Equal(2, weeks.Length);
            Assert.Equal("2020", seasonName);

        }
    }
}
