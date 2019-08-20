using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Data.Services;
using BeaverLeague.Tests.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BeaverLeague.Tests.Core
{
    public class SeasonTests
    {
        [Fact]
        public void CanCeateSetOfMatches()
        {
            var season = new Season("2019");
            var matchSet = season.NewMatchSet(matchSetDate);

            Assert.Equal(matchSetDate, matchSet.Date);
        }

        [Fact]
        public void Foo()
        {
            var season = new Season("2019");
            var matchSet = season.NewMatchSet(matchSetDate);

            var golfer1 = new Golfer()
            {
                Id = 1,
                LeagueHandicap = 10
            };

            var golfer2 = new Golfer
            {
                Id = 2,
                LeagueHandicap = 7
            };


            var match = matchSet.NewMatchResult(golfer1, 3, true, golfer2, 2, false);

            


        }

        readonly DateTime matchSetDate = new DateTime(2019, 10, 3);
    }
}
