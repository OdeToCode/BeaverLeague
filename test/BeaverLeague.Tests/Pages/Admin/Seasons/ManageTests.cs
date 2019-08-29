using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Tests.Helpers;
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
        public async Task DisplaysCurrentSeasonName()
        {
            using var scope = factory.Services.GetShortLivedDbContext<LeagueDbContext>();
            var db = scope.Db;
            db.Seasons.Add(new Season("2020"));
            db.SaveChanges();

            var client = factory.CreateClient();
            var response = await client.GetAsync("/Admin/Seasons/Manage");
            var document = await response.GetDocumentAsync();
            var seasonName = document.QuerySelector("#current-season").TextContent;

            Assert.Equal("2020", seasonName);

        }
    }
}
