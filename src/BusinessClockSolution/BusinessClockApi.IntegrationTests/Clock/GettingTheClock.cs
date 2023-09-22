using Alba;
using BusinessClockApi.Services;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace BusinessClockApi.IntegrationTests.Clock;
public class GettingTheClock
{

    [Fact]
    public async Task GivesMeA200()
    {
        var host = await AlbaHost.For<Program>();

        await host.Scenario(api =>
        {
            api.Get.Url("/clock");
            api.StatusCodeShouldBeOk();
        });
    }

    [Fact]
    public async Task DuringOpenHours()
    {

        // Given 
        var expectedResponse =  ClockResponse.CreateOpen();
        var host = await AlbaHost.For<Program>(config =>
        {
            var fakeClock = Substitute.For<ISystemTime>();
            fakeClock.GetCurrent().Returns(new DateTime(2023, 9, 22, 16, 59, 00));
            config.ConfigureServices(services =>
            {
                services.AddSingleton<ISystemTime>(fakeClock);
            });
        });

        // When

        var response = await host.Scenario(api =>
        {
            api.Get.Url("/clock");

        });

        var result = response.ReadAsJson<ClockResponse>();

        Assert.Equal(expectedResponse, result);

    }
    [Fact]
    public async Task AfterHours()
    {

        // Given 
        var expectedResponse = ClockResponse.CreateClosed(new DateTime(1969, 04, 21, 9, 00, 00));
        var host = await AlbaHost.For<Program>(config =>
        {
            var fakeClock = Substitute.For<ISystemTime>();
            fakeClock.GetCurrent().Returns(new DateTime(1969, 4, 20, 23, 59, 00));
            config.ConfigureServices(services =>
            {
                services.AddSingleton<ISystemTime>(fakeClock);
            });
        });

        // When

        var response = await host.Scenario(api =>
        {
            api.Get.Url("/clock");

        });

        var result = response.ReadAsJson<ClockResponse>();
        Assert.NotNull(result);
        Assert.Equal(expectedResponse, result);


    }
}
