using BeaverLeague.Core.Models;
using Xunit;
using static Xunit.Assert;

namespace BeaverLeague.Tests.Core.Models
{
    public class SeasonTests
    {
        [Fact]
        public void SeasonHasActivePlayers()
        {
            var season = new Season();
            var player = new Golfer();

            season.AddActiveGolfer(player);

            True(season.Golfers.Count == 1);
        }
    }
}