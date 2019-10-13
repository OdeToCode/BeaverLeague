using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;

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
            return dbSet.Find(matchSetId);
        }
    }
}
