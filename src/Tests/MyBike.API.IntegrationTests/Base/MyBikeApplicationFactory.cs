// ReSharper disable ClassNeverInstantiated.Global

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MyBike.Api.IntegrationTests.Base;

public sealed class MyBikeWebApplicationFactory : WebApplicationFactory<Program>
{
    public readonly HttpClient HttpClient;

    public MyBikeWebApplicationFactory()
    {
        HttpClient = CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
    }
}