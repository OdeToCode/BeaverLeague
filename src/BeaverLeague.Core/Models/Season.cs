using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeaverLeague.Core.Models
{
    public class Season
    {
        public Season()
        {
            Name = "";
            Weeks = new HashSet<MatchSet>();
        }

        [Required, MaxLength(80)]
        public string Name { get; set; }
        public int Id { get; set; }
        public ICollection<MatchSet> Weeks   { get; set; }

        public MatchSet AddWeek(MatchSet matchSet)
        {
            matchSet.SeasonId = Id;
            Weeks.Add(matchSet);
            return matchSet;
        }
    }
}
