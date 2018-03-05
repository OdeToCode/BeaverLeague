
using Microsoft.AspNetCore.Authentication.Cookies;

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
                };

                return options;
            }
        }
    }
}
