using BeaverLeague.Core.Models;
using BeaverLeague.Core.Services;
using BeaverLeague.Data.Queries;
using BeaverLeague.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeaverLeague.Web.Pages.Admin.Seasons.Weeks
{
    public class CreateModel : PageModel
    {
        private readonly LeagueData leagueData;

        public Season Season { get; set; } = new Season();

        [BindProperty]
        public MatchSet MatchSet { get; set; } = new MatchSet();
        public IMatchDayFinder MatchDayFinder { get; }

        public CreateModel(LeagueData leagueData, IMatchDayFinder matchDayFinder)
        {
            this.leagueData = leagueData;
            MatchDayFinder = matchDayFinder;
        }

        public void OnGet(int seasonId)
        {
            var seasonQuery = new SeasonByIdQuery(seasonId);
            Season = leagueData.Execute(seasonQuery);
            MatchSet.SeasonId = seasonId;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

            }
            return Page();
        }
    }
}