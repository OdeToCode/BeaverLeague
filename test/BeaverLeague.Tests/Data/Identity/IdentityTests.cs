using System.Threading.Tasks;
using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using Xunit;
using static Xunit.Assert;
using System.Linq;
using BeaverLeague.Web.Messaging;

namespace BeaverLeague.Tests.Data.Identity
{
    public class IdentityTests
    {
        public IdentityTests()
        {
            _db =  new Db<LeagueDb>(options => new LeagueDb(options));
            _managers = new SecurityManagers(_db);
        }

        [Fact]
        public async Task LoginUserCommandCanLoginUser()
        {
            var password = "123aBc!@#";
            var manager = _managers.UserManager;
            var golfer = CreateGolfer();
            await manager.CreateAsync(golfer, password);
            var command = new LoginUserCommand()
            {
                EmailAddress = "scott@OdeToCode.com",
                Password = password,
                RememberMe = true
            };
            var handler = new LoginUserCommandHandler(_managers.UserManager, _managers.SignInManager);
            var result = await handler.Handle(command);

            Equal(result.Success, true);
        }

        [Fact]
        public async Task CanAddUserToDatbase()
        {
            var manager = _managers.UserManager;
            var golfer = CreateGolfer();

            var result = await manager.CreateAsync(golfer);

            var db = _db.NewContext();
            var user = db.Golfers.Single();
            True(result.Succeeded, "CreateAsync failed");
            Equal(golfer.FirstName, user.FirstName);
        }

        [Fact]
        public async Task CanLoginUser()
        {
            var manager = _managers.UserManager;
            var signIn = _managers.SignInManager;
            var golfer = CreateGolfer();
            await manager.CreateAsync(golfer, "123abcABC#@!");
            
            var signInResult = await signIn.PasswordSignInAsync(golfer, "123abcABC#@!", false, false);

            Equal(true, signInResult.Succeeded);
        }

        [Fact]
        public async Task CanFailLogin()
        {
            var manager = _managers.UserManager;
            var signIn = _managers.SignInManager;
            var golfer = CreateGolfer();
            await manager.CreateAsync(golfer, "123abcABC#@!");
            
            var signInResult = await signIn.PasswordSignInAsync(golfer, "123", false, false);

            Equal(false, signInResult.Succeeded);
        }

        private static Golfer CreateGolfer()
        {
            var golfer = new Golfer()
            {
                FirstName = "Scott",
                LastName = "Allen",
                Handicap = 2,
                MembershipId = 2,
                Username = "sallen"
            };
            return golfer;
        }


        readonly Db<LeagueDb> _db;
        readonly SecurityManagers _managers;
    }
}
