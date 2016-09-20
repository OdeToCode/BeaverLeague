using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BeaverLeague.Web.Security
{
    public class AuthorizationPolicies
    {        
        public AuthorizationPolicy IsAdmin()
        {
            return NewPolicyBuilder()
                    .RequireClaim("isAdmin")
                    .Build();
        }

        AuthorizationPolicyBuilder NewPolicyBuilder()
        {
            var scheme = new IdentityCookieOptions().ExternalCookieAuthenticationScheme;                       
            return new AuthorizationPolicyBuilder(scheme);
        }
    }
}
