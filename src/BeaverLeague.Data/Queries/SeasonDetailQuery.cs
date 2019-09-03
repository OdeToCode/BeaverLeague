using System.Linq;
using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BeaverLeague.Data.Queries
{
    public class SeasonDetailQuery : IQuery<Season, Season>
    {
        private readonly int id;

        public SeasonDetailQuery(int id)
        {
            this.id = id;
        }

        public Season Execute(DbSet<Season> dbSet)
        {
            return dbSet.Include(s => s.Weeks)
                        .ThenInclude(m => m.Matches)
                        .First(s => s.Id == id);
        }
    }
}