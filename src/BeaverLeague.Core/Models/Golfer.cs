using System;
using System.ComponentModel.DataAnnotations;

namespace BeaverLeague.Core.Models
{
    public class Golfer
    {
        public int Id { get; set; }

        [Display(Name = "18 hole Course Handicap"), Range(-36, 36)]
        public int LeagueHandicap { get; set; } = 18;

        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        [MaxLength(80), Required, Display(Name ="First Name")]
        public string FirstName { get; set; } = "";

        [MaxLength(80), Required, Display(Name = "Last Name")]
        public string LastName { get; set; } = "";

        [MaxLength(80), Display(Name ="Email"), DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; } = "";

        [MaxLength(80), Required, Display(Name ="Phone"), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = "";

        public TeeType Tee { get; set; } = TeeType.White;

        public bool IsCardMatch { get; set; } = false;
    }
}
