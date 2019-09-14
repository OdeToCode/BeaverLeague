using System;

namespace BeaverLeague.Core.Services
{
    public interface IMatchDayFinder
    {
        DateTime FindNextMatchDay(DateTime currentDate);
    }
}
