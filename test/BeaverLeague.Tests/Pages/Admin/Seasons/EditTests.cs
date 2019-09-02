using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Tests.Helpers;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BeaverLeague.Tests.Pages.Admin.Seasons
{
    public class EditTests : IClassFixture<BeaverLeagueWebFactory>
    {
        private readonly BeaverLeagueWebFactory factory;

        public EditTests(BeaverLeagueWebFactory factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task CanCreateNewSeason()
        {
            var client = factory.CreateClient();
            var emptyForm = await client.GetAsync("/Admin/Seasons/Edit");
            var formDocument = await emptyForm.GetDocumentAsync();

            var name = Guid.NewGuid().ToString();
            var season = new Season() { Name = name };

            var formPost = await client.SendFormAsync(formDocument, "Season", season);
            var postDocument = await formPost.GetDocumentAsync();
            
            using var scope = factory.Services.GetScopedDbContext<LeagueDbContext>();

            Assert.Single(scope.Db.Seasons.Where(s => s.Name == name));
        }

        [Fact]
        public async Task CanDisplaySeasonForEdit()
        {
            using var scope = factory.Services.GetScopedDbContext<LeagueDbContext>();
            var db = scope.Db;

            var season = new Season() { Name = Guid.NewGuid().ToString() };
            db.Seasons.Add(season);
            db.SaveChanges();

            var client = factory.CreateClient();
            var form = await client.GetAsync($"/Admin/Seasons/Edit/{season.Id}");
            var document = await form.GetDocumentAsync();

            var input = document.QuerySelector($"#Season_Id").Attributes["value"].Value;
            Assert.Equal(season.Id.ToString(), input);
        }
    }
}
