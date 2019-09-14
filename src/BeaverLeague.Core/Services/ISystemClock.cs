using System;

namespace BeaverLeague.Core.Services
{
    public interface ISystemClock
    {
        public DateTime CurrentTime { get; }
    }
}
