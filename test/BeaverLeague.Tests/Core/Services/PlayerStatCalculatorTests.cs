using BeaverLeague.Core.Models;
using BeaverLeague.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BeaverLeague.Tests.Core.Services
{
    public class PlayerStatCalculatorTests
    {
        [Fact]
        public void CalcualtesStatsCorrectly()
        {
            var calculator = new PlayerStatisticsCalculator();
            var results = calculator.Calculate(CreateTestSets());

            var golfer1 = results.Single(r => r.GolferId == 1);

            
            Assert.Equal(1, golfer1.Rank);
            Assert.Equal("Scott A.", golfer1.Name);
            Assert.Equal(44, golfer1.GrossScore);
            Assert.Equal(32, golfer1.NetScore);
            Assert.Equal(10.0m, golfer1.LastPoints);
            Assert.Equal(16, golfer1.TotalRounds);
            Assert.Equal(120.0m, golfer1.TwelveBestPoints);
        }

        IEnumerable<MatchSet> CreateTestSets()
        {
            var golfers = new List<Golfer>()
            {
                new Golfer { Id = 1, FirstName = "Scott", LastName = "Allen", LeagueHandicap = 12 },
                new Golfer { Id = 2, FirstName = "Two", LastName = "Allen", LeagueHandicap = 1 },
                new Golfer { Id = 3, FirstName = "Three", LastName = "Allen", LeagueHandicap = 2 },
                new Golfer { Id = 4, FirstName = "Four", LastName = "Allen", LeagueHandicap = 3 },
                new Golfer { Id = 5, FirstName = "Five", LastName = "Allen", LeagueHandicap = 4 },
                new Golfer { Id = 6, FirstName = "Six", LastName = "Allen", LeagueHandicap = 5 },
            };

            var sets = new List<MatchSet>();

            for (var i = 0; i < 15; i++)
            {
                var set = new MatchSet(DateTime.Now.AddDays(-i));
                sets.Add(set);
                CreateTestResult(set, golfers);
            }

            var lastSet = new MatchSet(DateTime.Now.AddDays(-100));
            sets.Add(lastSet);
            lastSet.AddResult(golfers[0], 50, 1, true, golfers[1], 34, 10, true);
            lastSet.AddResult(golfers[2], 50, 1, true, golfers[3], 37, 10, true);
            lastSet.AddResult(golfers[4], 50, 1, true, golfers[5], 38, 10, true);

            return sets;
        }

        private void CreateTestResult(MatchSet set, List<Golfer> golfers)
        {
            set.AddResult(golfers[0], 44, 10, true, golfers[1], 34, 1, true);
            set.AddResult(golfers[2], 40, 9, true, golfers[3], 37, 2, true);
            set.AddResult(golfers[4], 42, 8, true, golfers[5], 38, 3, true);
        }
    }
}
