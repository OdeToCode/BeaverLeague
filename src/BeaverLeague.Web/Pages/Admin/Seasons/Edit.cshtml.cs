using BeaverLeague.Core.Models;
using BeaverLeague.Data.Queries;
using BeaverLeague.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Globalization;

namespace BeaverLeague.Web.Pages.Admin.Seasons
{
    public class EditModel : PageModel
    {
        private readonly LeagueData leagueData;

        public string Header { get; set; } = "Create a new season";

        [BindProperty]
        public Season Season { get; set; } = new Season { Name = DateTime.Now.Year.ToString(CultureInfo.CurrentCulture) };

        public EditModel(LeagueData leagueData)
        {
            this.leagueData = leagueData;
        }

        public IActionResult OnGet(int id)
        {
            if (id != 0)
            {
                var query = new SeasonByIdQuery(id);
                Season = leagueData.Execute(query);
                if (Season == null)
                {
                    // todo: better not found page?
                    return NotFound();
                }
                Header = $"Edit {Season.Name}";
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    leagueData.Add(Season);
                }
                else
                {
                    leagueData.Update(Season);
                }
                leagueData.Commit();
                return RedirectToPage("/Admin/Seasons/Manage");
            }
            else
            {
                return Page();
            }
        }
    }
}