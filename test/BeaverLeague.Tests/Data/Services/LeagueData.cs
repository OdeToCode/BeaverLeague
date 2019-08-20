using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Data.Services;
using Xunit;

namespace BeaverLeague.Tests.Data.Services
{
    public class LeagueDataTests
    {
        private LeagueDbContext leagueDbContext;

        [Fact]
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
    }
}
