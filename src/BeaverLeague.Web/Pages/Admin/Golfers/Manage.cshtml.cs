using System.Collections.Generic;
using System.Linq;
using BeaverLeague.Core.Models;
using BeaverLeague.Data.Queries;
using BeaverLeague.Data.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeaverLeague.Web.Pages.Admin.Golfers
{
    public class ManageModel : PageModel
    {
        private readonly LeagueData leagueData;

        public IEnumerable<Golfer> Golfers { get; set; } = Enumerable.Empty<Golfer>();

        public ManageModel(LeagueData leagueData)
        {
            this.leagueData = leagueData;
        }

        public void OnGet()
        {
            var query = new AllGolfersQuery();
            Golfers = leagueData.Execute(query);
        }
    }
}