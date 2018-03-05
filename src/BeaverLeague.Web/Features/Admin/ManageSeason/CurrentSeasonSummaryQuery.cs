using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeaverLeague.Web.Features.Admin.ManageSeason
{
    public class CurrentSeasonSummaryQuery : IRequest<CurrentSeasonSummaryResult>
    {
    }

    public class CurrentSeasonSummaryResult
    {
        public Season CurrentSeason { get; set; }
        public List<MatchSet> MatchSets { get; set; }
    }

    public class CurrentSeasonSummaryQueryHandler 
        : IRequestHandler<CurrentSeasonSummaryQuery, CurrentSeasonSummaryResult>
    {
        private readonly LeagueDb _db;

        public CurrentSeasonSummaryQueryHandler(LeagueDb db)
        {
            _db = db;
        }

        public async Task<CurrentSeasonSummaryResult> Handle(CurrentSeasonSummaryQuery message, CancellationToken cancel)
        {
            var result = new CurrentSeasonSummaryResult();
            result.CurrentSeason = await _db.Seasons.SingleOrDefaultAsync(s => s.IsCurrent);

            if (result.CurrentSeason != null)
            {
                result.MatchSets =
                        await _db.Entry<Season>(result.CurrentSeason)
                           .Collection(s => s.MatchSets)
                           .Query()
                           .Where(r => r.SeasonId == result.CurrentSeason.Id)
                           .OrderByDescending(r => r.MatchSetNumber)
                           .ToListAsync();
            }
            return result;
        }
    }
}
