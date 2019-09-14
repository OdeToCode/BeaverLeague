using System;

namespace BeaverLeague.Core.Services
{
    public class SystemClock : ISystemClock
    {
        public DateTime CurrentTime => DateTime.Now;
    }
}
