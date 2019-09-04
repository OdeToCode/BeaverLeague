using BeaverLeague.Core.Models;
using BeaverLeague.Data.Queries;
using BeaverLeague.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeaverLeague.Web.Pages.Admin.Weeks
{
    public class CreateModel : PageModel
    {
        private readonly LeagueData leagueData;

        public Season Season { get; set; } = new Season();
        
        [BindProperty]
        public MatchSet MatchSet { get; set; } = new MatchSet();

        public CreateModel(LeagueData leagueData)
        {
            this.leagueData = leagueData;
        }

        public void OnGet(int seasonId)
        {
            var seasonQuery = new SeasonByIdQuery(seasonId);
            Season = leagueData.Execute(seasonQuery);
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