namespace BeaverLeague.Core.Models
{
    public class Match
    {
        public int Id { get; set; }

        public Golfer GolferA { get; set; }

        public Golfer GolferB { get; set; }
    }
}
