using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BeaverLeague.Web.Security
{   
    public class SignInManager
    {               
        public SignInManager(LeagueDb db, 
                             PasswordManager passwordManager,
                             IHttpContextAccessor contextAccessor, 
                             ILogger<SignInManager> logger)
        {
            _db = db;
            _passwordManager = passwordManager;
            _contextAccessor = contextAccessor;
            _logger = logger;
        }

        public async Task<SignInResult> SignInGolferAsync(string emailAddress, string password, bool persistent)
        {
            if (string.IsNullOrEmpty(emailAddress)) throw new ArgumentException(nameof(emailAddress));
            if (string.IsNullOrEmpty(password)) throw new ArgumentException(nameof(password));

            var result = new SignInResult();
            await DoSignIn(emailAddress, password, result);
            AddErrorsOnFailure(result);
            return result;
        }

        public async Task<bool> SignOutGolferAsync()
        {
            await _contextAccessor.HttpContext.Authentication.SignOutAsync(SchemeName);
            return true;
        }

        public static readonly string SchemeName = CookieAuthenticationDefaults.AuthenticationScheme;

        private static void AddErrorsOnFailure(SignInResult result)
        {
            if (!result.Success && result.Errors.Count == 0)
            {
                result.Errors.Add("Invalid email address or password");
            }
        }

        private async Task DoSignIn(string emailAddress, string password, SignInResult result)
        {
            var golfer = await _db.Golfers.FirstOrDefaultAsync(g => g.EmailAddress == emailAddress);           
            if (golfer != null)
            {
                if (_passwordManager.VerifyPassword(golfer, password))
                {
                    var identity = CreateIdentity(golfer);
                    await _contextAccessor.HttpContext.Authentication.SignInAsync(SchemeName, identity);
                    result.Success = true;
                    _logger.LogInformation("User {@golfer} logged in", golfer);
                }
            }
            if (!result.Success)
            {
                _logger.LogWarning("Invalid login attempt by {emailAddress}", emailAddress);
            }
        }

        private ClaimsPrincipal CreateIdentity(Golfer golfer)
        {
            var principal = new ClaimsPrincipal();
            var identity = new ClaimsIdentity(SchemeName);
            identity.AddClaim(new Claim(ClaimTypes.Email, golfer.EmailAddress));
            identity.AddClaim(new Claim(identity.NameClaimType, golfer.FirstName));
            if (golfer.IsAdmin)
            {
                identity.AddClaim(new Claim("isAdmin", "true"));
            }
            principal.AddIdentity(identity);
            return principal;
        }

        private readonly LeagueDb _db;
        private readonly PasswordManager _passwordManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogger<SignInManager> _logger;

    }
}
