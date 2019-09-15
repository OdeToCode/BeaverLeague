using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeaverLeague.Core.Models
{
    public class MatchSet
    {
        public MatchSet()
        {
            Matches = new HashSet<MatchResult>();
        }

        public MatchSet(DateTime date)
        {
            Date = date;
            Matches = new HashSet<MatchResult>();
        }

        public int Id { get; set; }
        public int SeasonId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public ICollection<MatchResult> Matches { get; set; }

        public MatchResult AddResult(Golfer playerA, int playerAScore, decimal playerAPoints, bool playerANextWeek, 
                                          Golfer playerB, int playerBScore, decimal playerBPoints, bool playerBNextWeek)
        {
            var match = new MatchResult();
            match.AddPlayer(playerA, playerAScore, playerAPoints, playerANextWeek);
            match.AddPlayer(playerB, playerBScore, playerBPoints, playerBNextWeek);
            Matches.Add(match);
            return match;

        }
    }
}
