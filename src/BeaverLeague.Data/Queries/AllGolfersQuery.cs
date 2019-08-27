using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BeaverLeague.Data.Queries
{
    public class AllGolfersQuery : IQuery<Golfer, IQueryable<Golfer>>
    {
        public IQueryable<Golfer> Execute(DbSet<Golfer> db)
        {
                var result = db.OrderByDescending(g => g.IsActive)
                               .ThenBy(g => g.LastName)
                               .ThenBy(g => g.FirstName);
                return result;
        }
    }
}
