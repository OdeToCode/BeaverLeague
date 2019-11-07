using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BeaverLeague.Data.Queries
{
    public class AllResultsForSeasonQuery : IQuery<MatchSet, IQueryable<MatchSet>>
    {
        public AllResultsForSeasonQuery(int seasonId)
        {
            SeasonId = seasonId;
        }

        public int SeasonId { get; }

        public IQueryable<MatchSet> Execute(DbSet<MatchSet> dbSet)
        {
            return dbSet.Include(m => m.Matches)
                        .ThenInclude(r => r.Players)
                        .ThenInclude(z => z.Golfer)
                        .Where(m => m.SeasonId == SeasonId);
        }
    }
}
