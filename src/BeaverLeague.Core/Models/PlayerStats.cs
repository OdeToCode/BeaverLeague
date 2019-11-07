using System.Collections.Generic;

namespace BeaverLeague.Core.Models
{
    public class PlayerStats
    {
        public PlayerStats()
        {
            Name = "";
            AllScores = new List<int>();
            AllPoints = new List<decimal>();
        }

        public int GolferId { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
        public int GrossScore { get; set; }
        public int Handicap { get; set; }
        public int NetScore { get; set; }
        public int TotalRounds { get; set; }
        public decimal LastPoints { get; set; }
        public decimal TwelveBestPoints { get; set; }
        public List<int> AllScores { get; }
        public List<decimal> AllPoints { get; }
    }
}
