using BeaverLeague.Core.Models;
using BeaverLeague.Data.Queries;
using BeaverLeague.Data.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeaverLeague.Web.Pages.Admin.Seasons
{
    public class ManageModel : PageModel
    {
        private readonly LeagueData leagueData;

        public Season CurrentSeason { get; set; } = new Season("");

        public ManageModel(LeagueData leagueData)
        {
            this.leagueData = leagueData;
        }

        public void OnGet()
        {
            var query = new CurrentSeasonQuery();
            CurrentSeason = leagueData.Execute(query);
        }
    }
}