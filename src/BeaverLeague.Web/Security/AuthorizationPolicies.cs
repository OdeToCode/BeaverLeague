using Microsoft.AspNetCore.Authorization;

namespace BeaverLeague.Web.Security
{
    public class AuthorizationPolicies
    {
        private AuthorizationOptions _options;

        public AuthorizationPolicies(AuthorizationOptions options)
        {
            _options = options;
        }

        public void Apply()
        {
            _options.AddPolicy(nameof(IsAdmin), IsAdmin());
        }

       
        AuthorizationPolicy IsAdmin()
        {
            var scheme = SignInManager.SchemeName;
            var builder = new AuthorizationPolicyBuilder(scheme);
            return 
                 builder.RequireClaim("isAdmin", "true")
                        .RequireClaim("department", "Sales")
                        .RequireClaim("canEdit", "true")
                    .Build();
        }

        AuthorizationPolicyBuilder NewPolicyBuilder()
        {
            var scheme = SignInManager.SchemeName;
            return new AuthorizationPolicyBuilder(scheme);
        }
    }
}
