using System.Net;
using FluentAssertions;
using MyBike.Api.IntegrationTests.Base;

namespace MyBike.Api.IntegrationTests;

public class HealthTests(MyBikeWebApplicationFactory factory) :
    IClassFixture<MyBikeWebApplicationFactory>
{
    [Fact]
    public async Task App_ShouldBeHealthy()
    {
        // Act
        var result = await factory.HttpClient.GetAsync("health");

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        var response = await result.GetRequestContentAsync();
        response.Should().Be("Healthy");
    }
}