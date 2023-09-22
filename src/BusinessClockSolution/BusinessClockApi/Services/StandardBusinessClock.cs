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
            return ClockResponse.CreateOpen();
        } else if(OpeningLaterToday()) {

            return  ClockResponse.CreateClosed(GetTodayOpeningTime());
        }


        var openingNext = dayOfTheWeek switch
        {
            DayOfWeek.Friday => now.AddDays(3),
            DayOfWeek.Saturday => now.AddDays(2),
            DayOfWeek.Sunday => now.AddDays(1),

            _ => now.AddDays(1)
        };

        openingNext = openingNext.Date.Add(openingTime);

        return ClockResponse.CreateClosed(openingNext);

         
        bool OpeningLaterToday() => hour < openingTime.Hours;
       
        DateTime GetTodayOpeningTime() => new DateTime(now.Year, now.Month, now.Day).Add(openingTime);
        }
    }
    
