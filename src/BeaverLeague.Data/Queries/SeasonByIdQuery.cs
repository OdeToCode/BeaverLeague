using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BeaverLeague.Data.Queries
{
    public class SeasonByIdQuery : IQuery<Season, Season>
    {
        private readonly int id;

        public SeasonByIdQuery(int id)
        {
            this.id = id;
        }

        public Season Execute(DbSet<Season> db)
        {
            return db.Find(id);
        }
    }
}
