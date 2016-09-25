using System.Collections.Generic;

namespace BeaverLeague.Web.Security
{
    public class SignInResult
    {
        public SignInResult()
        {
            Success = false;
            Errors = new List<string>();
        }

        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
