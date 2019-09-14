using BeaverLeague.Core.Models;
using System;
using System.Linq;
using Xunit;

namespace BeaverLeague.Tests.Core.Models
{
    public class SeasonTests
    {
        [Fact]
        public void CanCeateSetOfMatches()
        {
            var season = new Season() { Name = seasonName, Id = 103 };
            var week = new MatchSet(matchSetDate);
            var matchSet = season.AddWeek(week);

            Assert.Equal(103, matchSet.SeasonId);
            Assert.Equal(matchSetDate, matchSet.Date);
        }

        [Fact]
        public void CanCreateMatchSetResult()
        {
            var season = new Season() { Name = seasonName, Id = 310 };
            var week = new MatchSet() { Date = matchSetDate };
            var matchSet = season.AddWeek(week);

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

            var match = matchSet.AddResult(golfer1, 3, 3.5m, true, golfer2, 2, 7.5m, false);

            Assert.Equal(1, matchSet.Matches.Count);
            Assert.Equal(11, matchSet.Matches.First().Players.Sum(p => p.Points));
        }

        [Theory]
        [InlineData(0, 11)]
        [InlineData(0.5, 10.5)]
        [InlineData(1, 10)]
        [InlineData(1.5, 9.5)]
        [InlineData(2, 9)]
        [InlineData(2.5, 8.5)]
        [InlineData(3, 8)]
        [InlineData(3.5, 7.5)]
        [InlineData(4, 7)]
        [InlineData(4.5, 6.5)]
        [InlineData(5, 6)]
        [InlineData(5.5, 5.5)]
        [InlineData(6, 5)]
        public void MatchPointsAlwaysTotalEleven(decimal scoreA, decimal scoreB)
        {
            var season = new Season() { Name = seasonName };
            var matchSet = new MatchSet(matchSetDate);
            season.AddWeek(matchSet);

            var golfer1 = new Golfer { Id = 1, LeagueHandicap = 10 };
            var golfer2 = new Golfer { Id = 2, LeagueHandicap = 7 };


            var match = matchSet.AddResult(golfer1, 3, scoreA, true, golfer2, 2, scoreB, false);
            Assert.Equal(11, match.Players.Sum(p => p.Points));
        }

        readonly string seasonName = "2019";
        readonly DateTime matchSetDate = new DateTime(2019, 10, 3);
    }
}
