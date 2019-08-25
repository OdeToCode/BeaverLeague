using Xunit;
using System.Threading.Tasks;
using BeaverLeague.Tests.Helpers;
using System.Linq;
using BeaverLeague.Core.Models;
using System;
using static BeaverLeague.Tests.Pages.Admin.Golfers.Edit;

namespace BeaverLeague.Tests.Pages.Admin.Golfers
{
    public class Edit : IClassFixture<EditWebFactory>
    {
        private readonly EditWebFactory factory;

        public Edit(EditWebFactory factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task CanLoadEditFormToCreateGolfer()
        {
            var client = factory.CreateClient();

            var response = await client.GetAsync("/Admin/Golfers/Edit");
            var document = await response.GetDocumentAsync();
            var header = document.QuerySelector("h2").TextContent;

            Assert.Equal("Create a Golfer", header);
        }

        [Fact]
        public async Task CanFailWhenGolferFailsValidation()
        {
            var client = factory.CreateClient();
            var emptyForm = await client.GetAsync("/Admin/Golfers/Edit");
            var formDocument = await emptyForm.GetDocumentAsync();

            var formPost = await client.SendFormAsync(formDocument);
            var errorDocument = await formPost.GetDocumentAsync();
            var spans = errorDocument.QuerySelectorAll("span");
            var validationMessage = spans.Where(s => s.TextContent.Contains("The First Name field is required"));

            Assert.Single(validationMessage);
        }

        [Fact]
        public async Task CanCreateGolfer()
        {
            var client = factory.CreateClient();
            var emptyForm = await client.GetAsync("/Admin/Golfers/Edit");
            var formDocument = await emptyForm.GetDocumentAsync();

            var golfer = new Golfer()
            {
                FirstName = "Annie",
                LastName = "Oaks",
                EmailAddress = "annie@example.com",
                PhoneNumber = "301-555-1212",
                LeagueHandicap = 12,
                Tee = TeeType.Red,
                IsActive = true
            };
            
            var formPost = await client.SendFormAsync(formDocument, "Golfer", golfer);
            var postDocument = await formPost.GetDocumentAsync();

            using var scope = factory.GetScope();
            var db = factory.GetLeagueDbContext(scope);
            Assert.Single(db.Golfers);
        }

        public class EditWebFactory : BeaverLeagueWebFactory { }
    }
}
