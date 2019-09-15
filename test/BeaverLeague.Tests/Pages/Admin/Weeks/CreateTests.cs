using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
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
            using var scope = factory.Services.GetScopedDbContext<LeagueDbContext>();

            var season = new Season();
            season.Name = Guid.NewGuid().ToString();
            scope.Db.Add(season);
            scope.Db.SaveChanges();

            var emptyForm = await client.GetAsync($"/Admin/Seasons/{season.Id}/Weeks/Create");
            var formDocument = await emptyForm.GetDocumentAsync();

            var formData = new Dictionary<string, string>()
            {
                { "MatchSet.SeasonId", season.Id.ToString() }
            };

            var formPost = await client.SendFormAsync(formDocument, formData);
            var postDocument = await formPost.GetDocumentAsync();

            using var verifyScope = factory.Services.GetScopedDbContext<LeagueDbContext>();
            var set = verifyScope.Db.MatchSets.Where(w => w.SeasonId == season.Id);
            Assert.Single(set);
            Assert.Equal(set.First().Date, new DateTime(2019, 09, 18));
        }
    }
}
