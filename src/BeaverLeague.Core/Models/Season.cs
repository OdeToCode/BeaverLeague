using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeaverLeague.Core.Models
{
    public class Season
    {
        public Season()
        {
            Weeks = new HashSet<MatchSet>();
        }

        [Required, MaxLength(80)]
        public string Name { get; set; }
        public int Id { get; set; }
        public ICollection<MatchSet> Weeks   { get; set; }

        public MatchSet AddWeek(DateTime date)
        {
            var set = new MatchSet(date);
            Weeks.Add(set);
            return set;
        }
    }
}
