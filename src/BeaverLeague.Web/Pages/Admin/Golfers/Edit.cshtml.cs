using BeaverLeague.Core.Models;
using BeaverLeague.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeaverLeague.Web.Pages.Admin.Golfers
{
    public class EditModel : PageModel
    {
        private readonly LeagueData leagueData;

        public string Header { get; set; } = "Create a Golfer";

        [BindProperty]
        public Golfer Golfer { get; set; } = new Golfer();

        public EditModel(LeagueData leagueData)
        {
            this.leagueData = leagueData;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                leagueData.Add(Golfer);
                leagueData.Commit();
                return RedirectToPage("/Admin/Golfers/Manage");
            }
            else
            {
                return Page();
            }
        }
    }
}