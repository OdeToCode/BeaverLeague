using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeaverLeague.Web.Components.Models
{
    public class AddMatchModel
    {
        public int GolferOneId { get; set; }
        public int GolferOneScore { get; set; }
        public decimal GolferOnePoints { get; set; }
        public bool GolferOnePlayNextWeek { get; set; }

        public int GolferTwoId { get; set; }
        public int GolferTwoScore { get; set; }
        public decimal GolferTwoPoints { get; set; }
        public bool GolferTwoPlayNextWeek { get; set; }
    }
}
