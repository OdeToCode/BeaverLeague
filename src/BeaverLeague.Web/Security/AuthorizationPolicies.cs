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
            return NewPolicyBuilder()
                    .RequireClaim("isAdmin", "true")
                    .Build();
        }

        AuthorizationPolicyBuilder NewPolicyBuilder()
        {
            var scheme = SignInManager.SchemeName;
            return new AuthorizationPolicyBuilder(scheme);
        }
    }
}
