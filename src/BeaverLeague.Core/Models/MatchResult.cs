using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverLeague.Core.Models
{
    public class MatchResult
    {
        public MatchResult()
        {
            Players = new List<PlayerResult>();
        }

        public int Id { get; set; }
        public int MatchSetId { get; set; }
        public IList<PlayerResult> Players { get; }

        public PlayerResult AddPlayer(Golfer golfer, int score, decimal points, bool playNextWeek)
        {
            if (golfer == null) throw new ArgumentNullException(nameof(golfer));

            var player = new PlayerResult
            {
                Golfer = golfer,
                PlayNextWeek = playNextWeek,
                Score = score,
                Strokes = golfer.LeagueHandicap,
                Points = points
            };

            Players.Add(player);
            return player;
        }
    }
}
