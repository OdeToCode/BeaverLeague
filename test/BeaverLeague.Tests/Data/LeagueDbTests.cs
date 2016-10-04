using BeaverLeague.Core.Models;
using System.Linq;
using BeaverLeague.Data;
using Xunit;
using static Xunit.Assert;

namespace BeaverLeague.Tests.Data
{
    public class LeagueDbTests
    {
        [Fact]
        public void CanAddGolfer()
        {
            using (var leagueData = _db.NewContext())
            {
                leagueData.Golfers.Add(new Golfer());
                leagueData.SaveChanges();
            }

            using (var leagueData = _db.NewContext())
            {
                Equal(1, leagueData.Golfers.Count());
            }
        }

        readonly DbInstance<LeagueDb> _db = new DbInstance<LeagueDb>(
            options => new LeagueDb(options));
    }
}
