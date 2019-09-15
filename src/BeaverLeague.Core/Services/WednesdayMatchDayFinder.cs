using System;

namespace BeaverLeague.Core.Services
{
    public class WednesdayMatchDayFinder : IMatchDayFinder
    {
        private readonly ISystemClock clock;

        public WednesdayMatchDayFinder(ISystemClock clock)
        {
            this.clock = clock;
        }

        public DateTime FindNextMatchDay()
        {
            var date = clock.CurrentTime.AddDays(1);
            while (date.DayOfWeek != DayOfWeek.Wednesday)
            {
                date = date.AddDays(1);
            }
            return date;
        }
    }
}
