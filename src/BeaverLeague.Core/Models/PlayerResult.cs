namespace BeaverLeague.Core.Models
{
    public class PlayerResult
    {
        public PlayerResult()
        {
            Golfer = new Golfer();
        }

        public int Id { get; set; }
        public int Score { get; set; }
        public int Strokes { get; set; }
        public bool PlayNextWeek { get; set; }
        public decimal Points { get; set; }
        public int MatchResultId { get; set; }
        public Golfer Golfer { get; set; }
    }
}
