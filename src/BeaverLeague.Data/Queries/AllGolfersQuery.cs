using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BeaverLeague.Data.Queries
{
    public class AllGolfersQuery : IQuery<Golfer, IQueryable<Golfer>>
    {
        public AllGolfersQuery(bool activeOnly = false, bool includeCardMatch = false)
        {
            ActiveOnly = activeOnly;
            IncludeCardMatch = includeCardMatch;
        }

        public bool ActiveOnly { get; }
        public bool IncludeCardMatch { get; }

        public IQueryable<Golfer> Execute(DbSet<Golfer> db)
        {
            var query = db.OrderByDescending(g => g.IsActive)
                           .ThenBy(g => g.LastName)
                           .ThenBy(g => g.FirstName)
                           .Select(g => g);

            if(ActiveOnly)
            {
                query = query.Where(g => g.IsActive);
            }

            if(!IncludeCardMatch)
            {
                query = query.Where(g => !g.IsCardMatch);
            }

            return query;
        }
    }
}
