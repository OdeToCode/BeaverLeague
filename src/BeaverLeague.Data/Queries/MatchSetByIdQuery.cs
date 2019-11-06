using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BeaverLeague.Data.Queries
{
    public class MatchSetByIdQuery : IQuery<MatchSet, MatchSet>
    {
        private readonly int matchSetId;

        public MatchSetByIdQuery(int matchSetId)
        {
            this.matchSetId = matchSetId;
        }

        public MatchSet Execute(DbSet<MatchSet> dbSet)
        {
            if (dbSet is null) throw new System.ArgumentNullException(nameof(dbSet));

            return dbSet
                .Include(m => m.Matches)
                .ThenInclude(r => r.Players)
                .ThenInclude(z => z.Golfer)
                .FirstOrDefault(m => m.Id == matchSetId);
        }
    }
}
