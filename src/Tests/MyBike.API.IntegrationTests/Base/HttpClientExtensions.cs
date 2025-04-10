using System.Text.Json;

namespace MyBike.Api.IntegrationTests.Base;

public static class HttpClientExtensions
{
    private static readonly JsonSerializerOptions JsonSettings = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
    };

    public static async Task<T?> GetRequestContentAsync<T>(this HttpResponseMessage httpResponseMessage) =>
        JsonSerializer.Deserialize<T>(
            await httpResponseMessage.Content.ReadAsStringAsync(),
            JsonSettings);

    public static Task<string> GetRequestContentAsync(this HttpResponseMessage httpResponseMessage)
        => httpResponseMessage.Content.ReadAsStringAsync();
}