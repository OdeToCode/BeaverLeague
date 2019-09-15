using BeaverLeague.Core.Models;
using BeaverLeague.Data.Queries;
using BeaverLeague.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace BeaverLeague.Web.Pages.Admin.Seasons
{
    public class ManageModel : PageModel
    {
        private readonly LeagueData leagueData;

        public Season CurrentSeason { get; set; } = new Season() { Name = "" };
        public IEnumerable<Season> Seasons { get; set; } = Enumerable.Empty<Season>();

        public ManageModel(LeagueData leagueData)
        {
            this.leagueData = leagueData;
        }

        public IActionResult OnGet()
        {
            var query = new AllSeasonsQuery();
            Seasons = leagueData.Execute(query);
            if (Seasons.Any())
            {
                CurrentSeason = Seasons.First();
            }
            else
            {
                return RedirectToPage("/Admin/Seasons/Edit");
            }
            return Page();
        }
    }
}