using System.Linq;
using System.Threading.Tasks;
using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Web.Messaging;
using MediatR;

namespace BeaverLeague.Web.Features.Admin.ManageMatches
{
    public class CreateMatchSetCommand : IAsyncRequest<CreateMatchSetResult>
    {
        public int SeasonId { get; set; }
    }

    public class CreateMatchSetResult : CommandResult
    {
        public MatchSet MatchSet { get; set; }
    }

    public class CreateMatchSetCommandHandler : IAsyncRequestHandler<CreateMatchSetCommand, CreateMatchSetResult>
    {
        private readonly LeagueDb _db;

        public CreateMatchSetCommandHandler(LeagueDb db)
        {
            _db = db;
        }

        public async Task<CreateMatchSetResult> Handle(CreateMatchSetCommand command)
        {
            var set = new MatchSet
            {
                SeasonId = command.SeasonId,
                MatchSetNumber = _db.MatchSets.Max(ms => ms.MatchSetNumber) + 1
            };
            _db.MatchSets.Add(set);
            await _db.SaveChangesAsync();

            return new CreateMatchSetResult {MatchSet = set};
        }
    }
}