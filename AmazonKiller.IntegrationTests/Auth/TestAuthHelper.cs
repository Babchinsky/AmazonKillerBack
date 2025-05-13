using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AmazonKiller.IntegrationTests.Auth;

public static class TestAuthHelper
{
    private static string? GetFixedCode(CustomWebApplicationFactory factory)
    {
        using var scope = factory.Services.CreateScope();
        var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
        return config.GetValue<string>("Verification:FixedCodeValue");
    }

    public static async Task<HttpClient> RegisterAndLoginAsync(CustomWebApplicationFactory factory)
    {
        var client = factory.CreateClient();
        var email = $"test_{Guid.NewGuid()}@mail.com";
        const string password = "StrongPass123";
        var code = GetFixedCode(factory);

        await client.PostAsJsonAsync("/api/auth/start-registration", new { Email = email, Password = password });
        await client.PostAsJsonAsync("/api/auth/confirm-registration", new { Email = email, Code = code });

        var loginResponse = await client.PostAsJsonAsync("/api/auth/login", new { Email = email, Password = password });
        var loginJson = await loginResponse.Content.ReadFromJsonAsync<Dictionary<string, string>>();
        var accessToken = loginJson!["accessToken"];

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        return client;
    }

    public static async Task<(HttpClient Client, string Email, string Password)> RegisterAndLoginWithCredentialsAsync(
        CustomWebApplicationFactory factory)
    {
        var client = factory.CreateClient();
        var email = $"test_{Guid.NewGuid()}@mail.com";
        const string password = "StrongPass123";
        var code = GetFixedCode(factory);

        await client.PostAsJsonAsync("/api/auth/start-registration", new { Email = email, Password = password });
        await client.PostAsJsonAsync("/api/auth/confirm-registration", new { Email = email, Code = code });

        var loginResponse = await client.PostAsJsonAsync("/api/auth/login", new { Email = email, Password = password });
        var loginJson = await loginResponse.Content.ReadFromJsonAsync<Dictionary<string, string>>();
        var accessToken = loginJson!["accessToken"];

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        return (client, email, password);
    }

    public static async Task<string> GetAccessTokenAsync(CustomWebApplicationFactory factory)
    {
        var client = factory.CreateClient();
        var email = $"test_{Guid.NewGuid()}@mail.com";
        const string password = "StrongPass123";
        var code = GetFixedCode(factory);

        await client.PostAsJsonAsync("/api/auth/start-registration", new { Email = email, Password = password });
        await client.PostAsJsonAsync("/api/auth/confirm-registration", new { Email = email, Code = code });

        var loginResponse = await client.PostAsJsonAsync("/api/auth/login", new { Email = email, Password = password });
        var loginJson = await loginResponse.Content.ReadFromJsonAsync<Dictionary<string, string>>();
        return loginJson!["accessToken"];
    }
}