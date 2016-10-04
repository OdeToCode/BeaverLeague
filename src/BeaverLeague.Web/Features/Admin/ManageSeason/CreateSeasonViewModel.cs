using System.ComponentModel.DataAnnotations;

namespace BeaverLeague.Web.Features.Admin.ManageSeason
{
    public class CreateSeasonViewModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
    }
}
