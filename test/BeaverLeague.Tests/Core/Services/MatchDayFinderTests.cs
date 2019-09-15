using BeaverLeague.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BeaverLeague.Tests.Core.Services
{

    public class StuckClock : ISystemClock
    {
        public DateTime CurrentTime => new DateTime(2019, 9, 6);
    }

    public class MatchDayFinderTests
    {
        [Fact]
        public void WednesdayMatchDayFinderWillFindNextWednesday()
        {
            var finder = new WednesdayMatchDayFinder(new StuckClock());
            var date = finder.FindNextMatchDay();
            Assert.Equal(11, date.Day);
            Assert.Equal(9, date.Month);
        }
    }
}
