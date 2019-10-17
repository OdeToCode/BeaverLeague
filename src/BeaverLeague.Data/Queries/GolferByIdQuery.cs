using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BeaverLeague.Data.Queries
{
    public class GolferByIdQuery : IQuery<Golfer, Golfer>
    {
        private readonly int id;

        public GolferByIdQuery(int id)
        {
            this.id = id;
        }

        public Golfer Execute(DbSet<Golfer> db)
        {
            if (db is null) throw new System.ArgumentNullException(nameof(db));

            var golfer = db.Find(id);
            return golfer;
        }
    }
}