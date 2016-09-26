using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Tests.Data;
using BeaverLeague.Web.Messaging;
using BeaverLeague.Web.Security;
using Microsoft.Extensions.Logging;
using Xunit;

namespace BeaverLeague.Tests.Web.Features.Account
{
    public class IdentityTests
    {
        public IdentityTests()
        {
            _db =  new Db<LeagueDb>(options => new LeagueDb(options));
            _passwordManager = new PasswordManager();
            _context = new HttpContextWithAuthentication();
            _logger = new LoggerFactory().CreateLogger<SignInManager>();
            _signInManager = new SignInManager(_db.NewContext(), _passwordManager, _context, _logger);

            SetupDatabaseState();
        }
      
        [Fact]
        public async void CanLoginUser()
        {
            var command = new LoginUserCommand("person@server.com", "123abc!@#", false);        
            var handler = new LoginUserCommandHandler(_signInManager);
            var result = await handler.Handle(command);

            Assert.Equal(true, result.Success);
        }

        [Fact]
        public async void CanFailLoginWithBadPassword()
        {
            var command = new LoginUserCommand("person@server.com", "123", false);       
            var handler = new LoginUserCommandHandler(_signInManager);

            var result = await handler.Handle(command);

            Assert.Equal(false, result.Success);
            Assert.True(result.Errors.Count > 0, "No errors present in the login result");
        }

        private void SetupDatabaseState()
        {
            var golfer = new Golfer()
            {
                FirstName = "Person",
                EmailAddress = "person@server.com"
            };
            _passwordManager.SetPassword(golfer, "123abc!@#");

            var context = _db.NewContext();
            context.Add(golfer);
            context.SaveChanges();
        }

        readonly Db<LeagueDb> _db;
        readonly PasswordManager _passwordManager;
        readonly SignInManager _signInManager;
        readonly HttpContextWithAuthentication _context;
        private ILogger<SignInManager> _logger;
    }
}
