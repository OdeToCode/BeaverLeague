using BeaverLeague.Core.Models;
using BeaverLeague.Core.Services;
using BeaverLeague.Data.Queries;
using BeaverLeague.Data.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace BeaverLeague.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LeagueData leagueData;
        private readonly PlayerStatisticsCalculator calculator;
        public IList<PlayerStats>? Results { get; private set; }

        public IndexModel(LeagueData leagueData, PlayerStatisticsCalculator calculator)
        {
            this.leagueData = leagueData;
            this.calculator = calculator;
        }

        public void OnGet()
        {
            var currentSeason = leagueData.Execute(new CurrentSeasonQuery());
            var matches = leagueData.Execute(new AllResultsForSeasonQuery(currentSeason.Id));
            Results = calculator.Calculate(matches);
        }
    }
}