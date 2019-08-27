using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BeaverLeague.Data.Queries
{

    public interface IQuery<TSet, TResult> where TSet : class
    {
        TResult Execute(DbSet<TSet> dbSet);
    }


    public class CurrentSeasonQuery : IQuery<Season, Season>
    {
        public Season Execute(DbSet<Season> dbSet)
        {
            var season = dbSet.Include(s => s.Weeks)
                              .ThenInclude(m => m.Matches)
                              .First();
            return season;
        }
    }
}
