using Alba;

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
        var expectedResponse = new ClockResponse(true, null);
        var host = await AlbaHost.For<Program>();

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
        //var expectedResponse = new ClockResponse(false, null);
        var host = await AlbaHost.For<Program>();

        // When

        var response = await host.Scenario(api =>
        {
            api.Get.Url("/clock");

        });

        var result = response.ReadAsJson<ClockResponse>();
        Assert.NotNull(result);
        Assert.False(result.open);

        Assert.NotNull(result.opensNext); // Weak -sauce..


    }
}
