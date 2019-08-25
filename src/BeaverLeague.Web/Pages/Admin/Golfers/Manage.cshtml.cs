using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeaverLeague.Core.Models;
using BeaverLeague.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeaverLeague.Web.Pages.Admin.Golfers
{
    public class ManageModel : PageModel
    {
        private readonly LeagueData leagueData;

        public IEnumerable<Golfer> Golfers { get; set; }

        public ManageModel(LeagueData leagueData)
        {
            this.leagueData = leagueData;
        }

        public void OnGet()
        {
            Golfers = leagueData.GetAllGolfers();
        }
    }
}