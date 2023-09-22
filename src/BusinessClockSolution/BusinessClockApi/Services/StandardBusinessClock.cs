namespace BusinessClockApi.Services;

public class StandardBusinessClock : IProvideTheBusinessClock
{
    private readonly ISystemTime _theClock;

    public StandardBusinessClock(ISystemTime theClock)
    {
        _theClock = theClock;
    }

    public ClockResponse GetClock()
    {
        var now = _theClock.GetCurrent();
        var dayOfTheWeek = now.DayOfWeek;

        var hour = now.Hour;

        var openingTime = new TimeSpan(9, 0, 0);
        var closingTime = new TimeSpan(17, 0, 0);

        var isOpen = dayOfTheWeek switch
        {

            DayOfWeek.Saturday => false,
            DayOfWeek.Sunday => false,
            _ => hour >= openingTime.Hours && hour < closingTime.Hours,
        };

   
        if (isOpen)
        {
            return new ClockResponse(true, null);
        } else if(OpeningLaterToday()) {
            return new ClockResponse(false, new DateTime(now.Year, now.Month, now.Day).Add(openingTime));
        }


        var openingNext = dayOfTheWeek switch
        {
            DayOfWeek.Friday => now.AddDays(3),
            DayOfWeek.Saturday => now.AddDays(2),
            DayOfWeek.Sunday => now.AddDays(1),

            _ => now.AddDays(1)
        };

        openingNext = openingNext.Date.Add(openingTime);

        return new ClockResponse(false, openingNext);

         bool OpeningLaterToday()
        {
            return hour < openingTime.Hours;
        }
    }
}