using System.ComponentModel.DataAnnotations;

namespace BeaverLeague.Core.Models
{
    public class Golfer
    {
        public int Id { get; set; }

        public int MembershipId { get; set; }

        public float Handicap { get; set; }

        [MaxLength(80), Required]
        public string FirstName { get; set; }

        [MaxLength(80), Required]
        public string LastName { get; set; }
    }
}