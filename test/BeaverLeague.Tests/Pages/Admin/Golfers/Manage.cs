using BeaverLeague.Core.Models;
using BeaverLeague.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static BeaverLeague.Tests.Pages.Admin.Golfers.Manage;

namespace BeaverLeague.Tests.Pages.Admin.Golfers
{
    public class Manage : IClassFixture<ManageWebFactory>
    {
        private readonly ManageWebFactory factory;

        public Manage(ManageWebFactory factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task ListGolfers()
        {
            using var scope = factory.GetScope();
            var db = factory.GetLeagueDbContext(scope);
            db.Golfers.Add(new Golfer { FirstName = "Test", LastName = "One", EmailAddress = "testone@example.com", PhoneNumber = "3015551212" });
            db.Golfers.Add(new Golfer { FirstName = "Test", LastName = "Two", EmailAddress = "testtwo@example.com", PhoneNumber = "3015551212" });
            db.Golfers.Add(new Golfer { FirstName = "Test", LastName = "Three", EmailAddress = "testthree@example.com", PhoneNumber = "3015551212" });
            db.SaveChanges();

            var client = factory.CreateClient();
            var response = await client.GetAsync("/Admin/Golfers/Manage");
            var document = await response.GetDocumentAsync();
            var rows = document.QuerySelectorAll("#golfers tr");

            Assert.Equal(3, rows.Length);
        }

        public class ManageWebFactory : BeaverLeagueWebFactory { }
    }
}
