using System.Threading.Tasks;
using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Data.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Xunit;
using static Xunit.Assert;
using System.Linq;

namespace BeaverLeague.Tests.Data.Identity
{
    public class IdentityTests
    {
        [Fact]
        public async Task CanAddUserToDatbase()
        {
            var manager = CreateGolferManager();
            var golfer = new Golfer()
            {
                FirstName = "Scott",
                LastName = "Allen",
                Handicap = 2,
                MembershipId= 2,
                Username = "sallen"
            };

            var result = await manager.CreateAsync(golfer);

            var db = _db.NewContext();

            var user = db.Golfers.Single();

            True(result.Succeeded, "IdentityResult not succedded");
            Equal(golfer.FirstName, user.FirstName);
        }
     
        [Fact]
        public async Task CanLoginUser()
        {
            True(false);
        }

        [Fact]
        public async Task CanFailLogin()
        {
            True(false);
        }

        private GolferManager CreateGolferManager()
        {
            var store = new GolferStore(_db.NewContext());
            var options = Options.Create(new IdentityOptions());
            var hasher = new PasswordHasher<Golfer>();
            var userValidators = new[] {new UserValidator<Golfer>()};
            var passwordValidators = new[] {new PasswordValidator<Golfer>()};
            var lookup = new UpperInvariantLookupNormalizer();
            var errors = new IdentityErrorDescriber();
            var provider = _db.Provider;
            var logger = new LoggerFactory().CreateLogger<GolferManager>();

            var manager = new GolferManager(store, options, hasher, userValidators, 
                                passwordValidators, lookup, errors, provider, logger);
            return manager;
        }

        readonly Db<LeagueDb> _db = new Db<LeagueDb>(
            options => new LeagueDb(options));
    }
}
