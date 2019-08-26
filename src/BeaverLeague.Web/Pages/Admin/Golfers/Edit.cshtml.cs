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

        public IActionResult OnGet(int id)
        {
            if(id != 0)
            {
                Golfer = leagueData.GetGolfer(id);
                if (Golfer == null)
                {
                    return NotFound();
                }
                Header = $"Edit {Golfer.FirstName} {Golfer.LastName}";
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if(ModelState.IsValid)
            {
                if (id == 0)
                {
                    leagueData.Add(Golfer);
                }
                else
                {
                    leagueData.Update(Golfer);
                }
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