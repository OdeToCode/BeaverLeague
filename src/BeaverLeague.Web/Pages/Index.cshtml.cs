using BeaverLeague.Data.Queries;
using BeaverLeague.Data.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeaverLeague.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LeagueData leagueData;

        public IndexModel(LeagueData leagueData)
        {
            this.leagueData = leagueData;
        }

        public void OnGet()
        {
            var currentSeason = leagueData.Execute(new CurrentSeasonQuery());
            var results = leagueData.Execute(new AllResultsForSeasonQuery(currentSeason.Id));
        }
    }
}