using BusinessClockApi.Services;

namespace BusinessClockApi.UnitTests;
public class StandardBusinessClockTests
{
    [Fact]
    public void Closed()
    {
        var fakeSystemTime = Substitute.For<ISystemTime>();
        fakeSystemTime.GetCurrent().Returns(new DateTime(1969, 4, 20, 23, 59, 59));
        IProvideTheBusinessClock clock = new StandardBusinessClock(fakeSystemTime);

        var response = clock.GetClock();

        Assert.False(response.open);
        Assert.NotNull(response.opensNext);
    }

    [Fact]
    public void Open()
    {
        var fakeSystemTime = Substitute.For<ISystemTime>();
        fakeSystemTime.GetCurrent().Returns(new DateTime(2023, 9, 22, 14, 37, 59));
        IProvideTheBusinessClock clock = new StandardBusinessClock(fakeSystemTime);

        var response = clock.GetClock();

        Assert.True(response.open);
        Assert.Null(response.opensNext);
    }
}
