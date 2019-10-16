using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BeaverLeague.Data.Queries
{
    public class AllActiveGolfersQuery : IQuery<Golfer, IQueryable<Golfer>>
    {
        public IQueryable<Golfer> Execute(DbSet<Golfer> dbSet)
        {
            var result = dbSet.Where(g => g.IsActive)
                              .OrderBy(g => g.FirstName)
                              .ThenBy(g => g.LastName);
            return result;
        }
    }
}
