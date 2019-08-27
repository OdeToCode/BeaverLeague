using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BeaverLeague.Data.Queries
{
    public class GolferQuery : IQuery<Golfer, Golfer>
    {
        private readonly int id;

        public GolferQuery(int id)
        {
            this.id = id;
        }

        public Golfer Execute(DbSet<Golfer> db)
        {
            var golfer = db.Find(id);
            return golfer;
        }
    }
}