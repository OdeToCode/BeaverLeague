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
        public IMatchDayFinder MatchDayFinder { get; }

        [BindProperty]
        public MatchSet MatchSet { get; set; } = new MatchSet();

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
            MatchSet.Date = MatchDayFinder.FindNextMatchDay();
        }

        public IActionResult OnPost(int seasonId)
        {
            if (ModelState.IsValid)
            {
                leagueData.Add(MatchSet);
                leagueData.Commit();
                return RedirectToPage("/Admin/Seasons/Detail", new { Id = seasonId });
            }
            return Page();
        }
    }
}