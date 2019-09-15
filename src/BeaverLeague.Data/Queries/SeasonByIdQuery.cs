using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            return db.Single(s => s.Id == id);
        }
    }
}
