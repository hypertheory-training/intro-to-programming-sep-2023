using System.Diagnostics.CodeAnalysis;

namespace BusinessClockApi.Services;

public class StandardBusinessClock : IProvideTheBusinessClock
{
    private readonly ISystemTime _theClock;
    private TimeSpan OpeningTime { get => new(9, 0, 0); }
    private TimeSpan ClosingTime { get => new(17, 0, 0); }

    public StandardBusinessClock(ISystemTime theClock) => _theClock = theClock;

    public ClockResponse GetClock()
    {

        var todays = GetTodaysInfo();

        var isOpenNow = todays.DayOfTheWeek switch
        {
            DayOfWeek.Saturday => false,
            DayOfWeek.Sunday => false,
            _ => IsDuringBusinessHours(),
        };


        if (isOpenNow)
        {
            return ClockResponse.CreateOpen();
        }

        if (OpeningLaterToday())
        {
            return ClockResponse.CreateClosed(GetTodayOpeningTime());
        }


        var openingNext = todays.DayOfTheWeek switch
        {
            DayOfWeek.Friday => todays.Date.AddDays(3),
            DayOfWeek.Saturday => todays.Date.AddDays(2),
            DayOfWeek.Sunday => todays.Date.AddDays(1),

            _ => todays.Date.AddDays(1)
        };

        openingNext = openingNext.Date.Add(OpeningTime);

        return ClockResponse.CreateClosed(openingNext);

        // Local Functions
        bool OpeningLaterToday() => todays.Hour < OpeningTime.Hours;

        DateTime GetTodayOpeningTime() => new DateTime(todays.Date.Year, todays.Date.Month, todays.Date.Day).Add(OpeningTime);

        (DateTime Date, DayOfWeek DayOfTheWeek, int Hour) GetTodaysInfo()
        {
            var now = _theClock.GetCurrent();
            return (now, now.DayOfWeek, now.Hour);
        };

        bool IsDuringBusinessHours() => todays.Hour >= OpeningTime.Hours && todays.Hour < ClosingTime.Hours;
    }
}


