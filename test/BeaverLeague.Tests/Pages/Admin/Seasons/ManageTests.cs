using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Tests.Helpers;
using System.Threading.Tasks;
using Xunit;
using static BeaverLeague.Tests.Pages.Admin.Seasons.ManageTests;

namespace BeaverLeague.Tests.Pages.Admin.Seasons
{
    public class ManageTests : IClassFixture<ManageTestsWebFactory>
    {
        private readonly ManageTestsWebFactory factory;

        public ManageTests(ManageTestsWebFactory factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task DisplaysCurrentSeasonName2()
        {
            using var scope = factory.Services.GetScopedDbContext<LeagueDbContext>();
            var db = scope.Db;
            db.Seasons.Add(new Season("2021"));
            db.SaveChanges();

            var client = factory.CreateClient();
            var response = await client.GetAsync("/Admin/Seasons/Manage");
            var document = await response.GetDocumentAsync();
            var seasonName = document.QuerySelector("#current-season").TextContent;

            Assert.Equal("2021", seasonName);

        }

        [Fact]
        public async Task DisplaysCurrentSeasonName()
        {
            using var scope = factory.Services.GetScopedDbContext<LeagueDbContext>();
            var db = scope.Db;
            db.Seasons.Add(new Season("2020"));
            db.SaveChanges();

            var client = factory.CreateClient();
            var response = await client.GetAsync("/Admin/Seasons/Manage");
            var document = await response.GetDocumentAsync();
            var seasonName = document.QuerySelector("#current-season").TextContent;

            Assert.Equal("2020", seasonName);

        }

        public class ManageTestsWebFactory : BeaverLeagueWebFactory { }
    }
}
