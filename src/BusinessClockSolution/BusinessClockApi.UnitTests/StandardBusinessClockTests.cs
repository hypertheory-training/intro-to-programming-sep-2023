using BusinessClockApi.Services;

namespace BusinessClockApi.UnitTests;
public class StandardBusinessClockTests
{
    [Theory]
    [InlineData("9/22/2023 8:59:00 AM", "9/22/2023 9:00:00 AM")]
    [InlineData("9/21/2023 5:00:00 PM", "9/22/2023 9:00:00 AM")]
    public void Closed(string currentTime, string openNext)
    {
        var fakeSystemTime = Substitute.For<ISystemTime>();
        fakeSystemTime.GetCurrent().Returns(DateTime.Parse(currentTime));
        IProvideTheBusinessClock clock = new StandardBusinessClock(fakeSystemTime);

        var response = clock.GetClock();

        Assert.False(response.open);
        Assert.NotNull(response.opensNext);
        Assert.Equal(response.opensNext.Value, DateTime.Parse(openNext));
    }

    [Theory]
    [InlineData("9/22/2023 9:00:00 AM")]
    [InlineData("9/22/2023 4:59:59 PM")]
    public void Open(string currentTime)
    {
        var fakeSystemTime = Substitute.For<ISystemTime>();
        fakeSystemTime.GetCurrent().Returns(DateTime.Parse(currentTime));
        IProvideTheBusinessClock clock = new StandardBusinessClock(fakeSystemTime);

        var response = clock.GetClock();

        Assert.True(response.open);
        Assert.Null(response.opensNext);
    }
}
