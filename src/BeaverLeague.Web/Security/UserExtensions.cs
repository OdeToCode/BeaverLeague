using System.Security.Claims;

namespace BeaverLeague.Web.Security
{
    public static class UserExtensions
    {
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.HasClaim("isAdmin", "true");
        }
    }
}
