using BeaverLeague.Core.Models;
using System.Linq;
using BeaverLeague.Data;
using Xunit;
using static Xunit.Assert;

namespace BeaverLeague.Tests.Data.Services
{
    public class LeagueDbTests
    {
        [Fact]
        public void CanAddGolfer()
        {
            var dbInstance = new LeagueDbInstance(nameof(CanAddGolfer));
            using (var leagueData = dbInstance.NewContext())
            {
                leagueData.Golfers.Add(new Golfer());
                leagueData.SaveChanges();
            }

            using (var leagueData = dbInstance.NewContext())
            {
                Equal(1, leagueData.Golfers.Count());
            }
        }
    }
}
