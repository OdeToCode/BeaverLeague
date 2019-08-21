using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Data.Services;
using System;
using System.Linq;
using Xunit;

namespace BeaverLeague.Tests.Data.Services
{
    public class LeagueDataTests
    {
        //[Fact]
        public void CanSaveAndRetrieveSeason()
        {
            var seasonName = nameof(CanSaveAndRetrieveSeason);
            var dbInstance = new LeagueDbInstance(nameof(CanSaveAndRetrieveSeason));
            var data = new LeagueData(dbInstance.NewContext());
            var season = new Season(seasonName);

            data.Add(season);
            data.Commit();

            var secondData = new LeagueData(dbInstance.NewContext());
            var secondSeason = secondData.GetCurrentSeason();

            Assert.Equal(season.Id, secondSeason.Id);
            Assert.Equal(season.Name, secondSeason.Name);
        }

       // [Fact]
        public void CanSaveSeasonGraph()
        {
            var dbInstance = new LeagueDbInstance(nameof(CanSaveSeasonGraph));
            var data = new LeagueData(dbInstance.NewContext());

            var season = new Season(nameof(CanSaveSeasonGraph));
            var golferA = new Golfer { Id = 1, LeagueHandicap = 8 };
            var golferB = new Golfer { Id = 3, LeagueHandicap = 2 };
            var golferC = new Golfer { Id = 5, LeagueHandicap = 2 };
            var golferD = new Golfer { Id = 7, LeagueHandicap = 2 };

            var week1 = season.NewWeek(DateTime.Now);
            week1.NewMatchResult(golferA, 44, 7, true, golferB, 36, 4, false);
            week1.NewMatchResult(golferC, 44, 7, true, golferD, 36, 4, false);

            var week2 = season.NewWeek(DateTime.Now);
            week2.NewMatchResult(golferA, 44, 7, true, golferD, 36, 4, false);
            week2.NewMatchResult(golferB, 44, 7, true, golferC, 36, 4, false);

            data.Add(season, golferA, golferB, golferC, golferD);
            data.Commit();

            var checkData = new LeagueData(dbInstance.NewContext());
            var checkSeason = checkData.GetCurrentSeason();

            Assert.Equal(2, checkSeason.Weeks.Count);
            Assert.Equal(2, checkSeason.Weeks.First().Matches.Count);
        }
    }
}
