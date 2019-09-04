using BeaverLeague.Core.Models;
using BeaverLeague.Data.Queries;
using BeaverLeague.Data.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeaverLeague.Web.Pages.Admin.Seasons
{
    public class DetailModel : PageModel
    {
        private readonly LeagueData leagueData;

        public Season Season { get; set; } = new Season();

        public DetailModel(LeagueData leagueData)
        {
            this.leagueData = leagueData;
        }

        public void OnGet(int id)
        {
            var query = new SeasonDetailQuery(id);
            Season = leagueData.Execute(query);
        }
    }
}