using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Tests.Helpers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BeaverLeague.Tests.Pages.Admin.Golfers
{
    public class ManageTests : IClassFixture<BeaverLeagueWebFactory>
    {
        private readonly BeaverLeagueWebFactory factory;

        public ManageTests(BeaverLeagueWebFactory factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task ListGolfers()
        {
            using var scope = factory.Services.GetScopedDbContext<LeagueDbContext>();
            var db = scope.Db;
            db.Golfers.Add(new Golfer { FirstName = "Test", LastName = "One", EmailAddress = "testone@example.com", PhoneNumber = "3015551212" });
            db.Golfers.Add(new Golfer { FirstName = "Test", LastName = "Two", EmailAddress = "testtwo@example.com", PhoneNumber = "3015551212" });
            db.Golfers.Add(new Golfer { FirstName = "Test", LastName = "Three", EmailAddress = "testthree@example.com", PhoneNumber = "3015551212" });
            db.SaveChanges();

            var client = factory.CreateClient();
            var response = await client.GetAsync(new Uri("/Admin/Golfers/Manage"));
            var document = await response.GetDocumentAsync();
            var rows = document.QuerySelectorAll("#golfers tbody tr");

            Assert.Equal(3, rows.Length);
        }
    }
}
