namespace BusinessClockApi.Services;

public class SuperDeluxeBusinessClock : IProvideTheBusinessClock
{
    //private readonly ISystemTime _systemTime;
    //private readonly ILookupCrapInThedatabase _database;

    public ClockResponse GetClock()
    {

        return new ClockResponse(false, null);
    }
}
