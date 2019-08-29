using System;
using System.Collections.Generic;

namespace BeaverLeague.Core.Models
{
    public class MatchSet
    {
        public MatchSet(DateTime date)
        {
            Date = date;
            Matches = new HashSet<MatchResult>();
        }

        public int Id { get; protected set; }
        public int SeasonId { get; set; }
        public DateTime Date { get; protected set; }
        public ICollection<MatchResult> Matches { get; protected set; }

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
