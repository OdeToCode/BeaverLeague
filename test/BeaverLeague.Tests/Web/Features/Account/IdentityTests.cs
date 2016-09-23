using System.Linq;
using System.Threading.Tasks;
using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Tests.Data;
using BeaverLeague.Web.Messaging;
using Xunit;

namespace BeaverLeague.Tests.Web.Features.Account
{
    public class IdentityTests
    {
        public IdentityTests()
        {
            _db =  new Db<LeagueDb>(options => new LeagueDb(options));
        }
      
        [Fact]
        public void CanLoginUser()
        {
            
        }

        [Fact]
        public void CanFailLogin()
        {
            
        }

        private static Golfer CreateGolfer()
        {
            var golfer = new Golfer()
            {
                FirstName = "Scott",
                LastName = "Allen",
                Handicap = 2,
                MembershipId = 2                
            };
            return golfer;
        }

        readonly Db<LeagueDb> _db;
    }
}
