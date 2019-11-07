using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BeaverLeague.Data.Queries
{
    public class CurrentSeasonQuery : IQuery<Season, Season>
    {
        public Season Execute(DbSet<Season> dbSet)
        {
            return dbSet.OrderBy(s => s.Id).FirstOrDefault();
        }
    }
}
