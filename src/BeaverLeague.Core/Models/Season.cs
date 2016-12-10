using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeaverLeague.Core.Models
{
    public class Season
    {
        public int Id { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }

        public bool IsCurrent { get; set; }

        public ICollection<MatchSet> MatchSets { get; set; }
    }
}