using System.Threading;
using System.Threading.Tasks;
using BeaverLeague.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BeaverLeague.Data.Identity
{
    public class GolferStore : IUserPasswordStore<Golfer>
    {
        private readonly LeagueDb _db;

        public GolferStore(LeagueDb db)
        {
            _db = db;
        }

        public Task<string> GetUserIdAsync(Golfer user, CancellationToken cancellationToken)
        {            
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(Golfer user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username);
        }

        public Task SetUserNameAsync(Golfer user, string userName, CancellationToken cancellationToken)
        {
            user.Username = userName;
            return Task.FromResult(0);
        }

        public Task<string> GetNormalizedUserNameAsync(Golfer user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username.ToLower());
        }

        public Task SetNormalizedUserNameAsync(Golfer user, string normalizedName, CancellationToken cancellationToken)
        {
            user.Username = normalizedName;
            return Task.FromResult(0);
        }

        public async Task<IdentityResult> CreateAsync(Golfer user, CancellationToken cancellationToken)
        {
            _db.Add(user);
            await _db.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateAsync(Golfer user, CancellationToken cancellationToken)
        {
            _db.Attach(user);
            _db.Update(user);
            await _db.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(Golfer user, CancellationToken cancellationToken)
        {
            _db.Remove(user);
            await _db.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public Task<Golfer> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var id = int.Parse(userId);
            return _db.Golfers.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
        }

        public Task<Golfer> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return _db.Golfers.FirstOrDefaultAsync(g => g.Username == normalizedUserName, cancellationToken);
        }

        public Task SetPasswordHashAsync(Golfer user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(Golfer user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(Golfer user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash != null);
        }

        public void Dispose()
        {

        }
    }
}
