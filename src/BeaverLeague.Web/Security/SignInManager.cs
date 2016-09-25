using System.Security.Claims;
using System.Threading.Tasks;
using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeaverLeague.Web.Security
{
    public class SignInManager
    {
        private readonly string _schemeName = "COOKIES";
        private readonly LeagueDb _db;
        private readonly PasswordManager _passwordManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public SignInManager(LeagueDb db, PasswordManager passwordManager, IHttpContextAccessor contextAccessor)
        {
            _db = db;
            _passwordManager = passwordManager;
            _contextAccessor = contextAccessor;
        }

        public async Task<SignInResult> SignInGolferAsync(string emailAddress, string password, bool persistent)
        {
            var result = new SignInResult();
            await DoSignIn(emailAddress, password, result);
            AddErrorsOnFailure(result);
            return result;
        }

        private static void AddErrorsOnFailure(SignInResult result)
        {
            if (!result.Success && result.Errors.Count == 0)
            {
                result.Errors.Add("Invalid email address or password");
            }
        }

        private async Task DoSignIn(string emailAddress, string password, SignInResult result)
        {
            var golfer = await _db.Golfers.FirstOrDefaultAsync(g => g.EmailAdress == emailAddress);
            if (golfer != null)
            {
                if (_passwordManager.VerifyPassword(golfer, password))
                {
                    var identity = CreateIdentity(golfer);
                    await _contextAccessor.HttpContext.Authentication.SignInAsync(_schemeName, identity);
                    result.Success = true;
                }
            }
        }

        private ClaimsPrincipal CreateIdentity(Golfer golfer)
        {
            var principal = new ClaimsPrincipal();
            var identity = new ClaimsIdentity(_schemeName);
            identity.AddClaim(new Claim(ClaimTypes.Email, golfer.EmailAdress));
            identity.AddClaim(new Claim(identity.NameClaimType, golfer.FirstName));                       
            return principal;
        }
    }
}
