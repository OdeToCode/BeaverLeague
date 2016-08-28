using System.Collections.Generic;

namespace BeaverLeague.Core.Models
{
    public class Season
    {
        public Season()
        {
            Golfers = new List<Golfer>();
        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public IList<Golfer> Golfers { get; protected set; }

        public void AddActiveGolfer(Golfer player)
        {
            Golfers.Add(player);
        }
    }
}