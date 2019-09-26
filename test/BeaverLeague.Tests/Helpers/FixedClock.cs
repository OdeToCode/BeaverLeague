using System;
using BeaverLeague.Core.Services;

namespace BeaverLeague.Tests.Helpers
{
    public class FixedClock : ISystemClock
    {
        public DateTime CurrentTime => new DateTime(2014, 10, 3);
    }
}
