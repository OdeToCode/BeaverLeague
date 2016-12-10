using System;
using System.Collections.Generic;

namespace BeaverLeague.Core.Models
{
    public class MatchSet
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public int MatchSetNumber { get; set; }
        public ICollection<Match> Matches { get; set; }
        public ICollection<MatchSetInactiveGolfer> Inactives { get; set; }
    }
}