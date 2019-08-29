using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BeaverLeague.Data.Queries
{
    public class CurrentSeasonQuery : IQuery<Season, Season>
    {
        public Season Execute(DbSet<Season> dbSet)
        {
            var season = dbSet.OrderByDescending(s => s.Id)
                              .Include(s => s.Weeks)
                              .ThenInclude(m => m.Matches)
                              .First();
            return season;
        }
    }
}
