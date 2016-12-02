using System.Threading.Tasks;
using BeaverLeague.Data;
using Microsoft.EntityFrameworkCore;
using BeaverLeague.Web.Features.Admin.ManageSeason;
using MediatR;

namespace BeaverLeague.Web.Messaging
{
    public class CurrentSeasonSummaryQuery : IAsyncRequest<CurrentSeasonViewModel>
    {
    }

    public class CurrentSeasonSummaryQueryHandler : IAsyncRequestHandler<CurrentSeasonSummaryQuery, CurrentSeasonViewModel>
    {
        private readonly LeagueDb _db;

        public CurrentSeasonSummaryQueryHandler(LeagueDb db)
        {
            _db = db;
        }

        public async Task<CurrentSeasonViewModel> Handle(CurrentSeasonSummaryQuery message)
        {
            var result = new CurrentSeasonViewModel();
            result.CurrentSeason = await _db.Seasons                                            
                                            .SingleOrDefaultAsync(s => s.IsCurrent);
            if (result.CurrentSeason != null)
            {
                //_db.Entry(result.CurrentSeason)
                //    .Collection(s => s.Rounds)
                //    .Query()
                //    .Where(r => r.)
            }
            return result;
        }
    }
}
