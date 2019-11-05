using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Tests.Helpers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BeaverLeague.Tests.Pages.Admin.Seasons
{
    public class DetailTests : IClassFixture<BeaverLeagueWebFactory>
    {
        private readonly BeaverLeagueWebFactory factory;

        public DetailTests(BeaverLeagueWebFactory factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task CanShowSeasonDetails()
        {
            var client = factory.CreateClient();
            using var scope = factory.Services.GetScopedDbContext<LeagueDbContext>();
            var season = new Season()
            {
                Name = Guid.NewGuid().ToString(),
            };
            season.Weeks.Add(new MatchSet(new DateTime(2019, 9, 11)));
            season.Weeks.Add(new MatchSet(new DateTime(2019, 9, 18)));
            season.Weeks.Add(new MatchSet(new DateTime(2019, 9, 25)));
            scope.Db.Add(season);
            scope.Db.SaveChanges();

            
            var response = await client.GetAsync(new Uri($"/Admin/Seasons/Detail/{season.Id}", UriKind.Relative));
            var document = await response.GetDocumentAsync();
            var header = document.QuerySelector("h2").TextContent;

            Assert.EndsWith(season.Name, header, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
