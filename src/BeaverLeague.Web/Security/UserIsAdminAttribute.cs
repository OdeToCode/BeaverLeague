using Microsoft.AspNetCore.Authorization;

namespace BeaverLeague.Web.Security
{
    public class UserIsAdminAttribute : AuthorizeAttribute
    {
        public UserIsAdminAttribute() : base("isAdmin")
        {
      
        }        
    }
}
