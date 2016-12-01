using System.Threading.Tasks;
using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Web.Messaging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeaverLeague.Web.Features.Api.Golfers
{
    public class UpdateActiveFlagCommand : IAsyncRequest<UpdateActiveFlagResult>
    {
        public int Id { get; set; }
        public bool Value { get; set; }
    }

    public class UpdateActiveFlagResult : CommandResult
    {
        public Golfer Golfer { get; set; }
    }

    public class UpdateActiveFlagHandler : IAsyncRequestHandler<UpdateActiveFlagCommand, UpdateActiveFlagResult>
    {
        private readonly LeagueDb _db;

        public UpdateActiveFlagHandler(LeagueDb db)
        {
            _db = db;
        }

        public async Task<UpdateActiveFlagResult> Handle(UpdateActiveFlagCommand command)
        {
            var result = new UpdateActiveFlagResult();
            var golfer = await _db.Golfers.FirstOrDefaultAsync(g => g.Id == command.Id);
            if (golfer != null)
            {
                golfer.IsActive = command.Value;
                await _db.SaveChangesAsync();
                result.Golfer = golfer;
            }
            else
            {
                result.Errors.Add($"Could not find golfer with an ID of {command.Id}");
            }
            return result;
        }
    }

}
