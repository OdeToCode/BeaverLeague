using System.Collections.Generic;

namespace BeaverLeague.Web.Messaging
{
    public class CommandResult
    {
        public CommandResult()
        {
            Errors = new List<string>();
        }

        public bool Success => Errors.Count == 0;
        public List<string> Errors { get; set; }
    }
}
