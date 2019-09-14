using System;

namespace BeaverLeague.Core.Services
{
    public class WednesdayMatchDayFinder : IMatchDayFinder
    {
        public DateTime FindNextMatchDay(DateTime currentDate)
        {
            currentDate = currentDate.AddDays(1);
            while (currentDate.DayOfWeek != DayOfWeek.Wednesday)
            {
                currentDate = currentDate.AddDays(1);
            }
            return currentDate;
        }
    }
}
