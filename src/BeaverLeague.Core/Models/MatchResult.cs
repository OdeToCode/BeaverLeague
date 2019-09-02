﻿using System.Collections.Generic;

namespace BeaverLeague.Core.Models
{
    public class MatchResult
    {
        public MatchResult()
        {
            Players = new HashSet<PlayerResult>();
        }

        public int Id { get; set; }
        public int MatchSetId { get; set; }
        public ICollection<PlayerResult> Players { get; set; }

        public PlayerResult AddPlayer(Golfer golfer, int score, decimal points, bool playNextWeek)
        {
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