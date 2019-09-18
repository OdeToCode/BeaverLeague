using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeaverLeague.Web.Pages.Admin.Seasons.Weeks
{
    public class ScoresModel : PageModel
    {
        public int WeekID { get; set; }
        public int SeasonID { get; set; }

        public void OnGet(int weekId, int seasonId)
        {

        }
    }
}