using BeaverLeague.Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BeaverLeague.Data.Identity
{
    public class GolferSignInManager : SignInManager<Golfer>
    {
        public GolferSignInManager(UserManager<Golfer> userManager, 
                                    IHttpContextAccessor contextAccessor, 
                                    IUserClaimsPrincipalFactory<Golfer> claimsFactory, 
                                    IOptions<IdentityOptions> optionsAccessor, 
                                    ILogger<SignInManager<Golfer>> logger) 
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger)
        {
        }
    }
}
