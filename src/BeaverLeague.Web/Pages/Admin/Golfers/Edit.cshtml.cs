using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeaverLeague.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeaverLeague.Web.Pages.Admin.Golfers
{
    public class EditModel : PageModel
    {
        public string Header { get; set; } = "Create a Golfer";
        public Golfer Golfer { get; set; } = new Golfer();

        public void OnGet()
        {

        }
    }
}