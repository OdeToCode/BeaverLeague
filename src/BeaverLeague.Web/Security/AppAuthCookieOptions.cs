using Microsoft.AspNetCore.Builder;

namespace BeaverLeague.Web.Security
{
    public static class AppCookieAuthentication 
    {
        public static CookieAuthenticationOptions Options
        {
            get
            {
                var options = new CookieAuthenticationOptions
                {
                    AutomaticAuthenticate = true,
                    AutomaticChallenge = true
                };

                return options;
            }
        }
    }
}
