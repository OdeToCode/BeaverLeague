using BeaverLeague.Data;
using BeaverLeague.Tests.Helpers;
using Xunit;
using static BeaverLeague.Tests.Pages.Admin.Season.ManageTests;

namespace BeaverLeague.Tests.Pages.Admin.Season
{
    public class ManageTests : IClassFixture<ManageTestsWebFactory>
    {
        private readonly ManageTestsWebFactory factory;

        public ManageTests(ManageTestsWebFactory factory)
        {
            this.factory = factory;
        }

        [Fact]
        public void DisplaysCurrentSeasonName()
        {
            using var scope = factory.Services.GetScopedDbContext<LeagueDbContext>();
            var db = scope.Db;
            db.Seasons.Add(new Season { });
            
            
            db.SaveChanges();

            var client = factory.CreateClient();
            var response = await client.GetAsync("/Admin/Golfers/Manage");
            var document = await response.GetDocumentAsync();
            var rows = document.QuerySelectorAll("#golfers tbody tr");

            Assert.Equal(3, rows.Length);

        }

        public class ManageTestsWebFactory : BeaverLeagueWebFactory { }
    }
}
