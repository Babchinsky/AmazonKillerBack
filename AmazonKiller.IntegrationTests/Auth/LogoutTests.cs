using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AmazonKiller.IntegrationTests.Auth;

public class LogoutTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    private static string? GetFixedCode(CustomWebApplicationFactory factory)
    {
        using var scope = factory.Services.CreateScope();
        var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
        return config.GetValue<string>("Verification:FixedCodeValue");
    }

    private async Task<string> RegisterAndLoginAsync(string email, string password)
    {
        // Start registration
        var startBody = new { Email = email, Password = password };
        var startResponse = await _client.PostAsJsonAsync("/api/auth/start-registration", startBody);
        startResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

        // Confirm registration
        var code = GetFixedCode(factory);
        var confirmBody = new { Email = email, Code = code };
        var confirmResponse = await _client.PostAsJsonAsync("/api/auth/confirm-registration", confirmBody);
        confirmResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

        // Login
        var loginResponse =
            await _client.PostAsJsonAsync("/api/auth/login", new { Email = email, Password = password });
        var loginJson = await loginResponse.Content.ReadFromJsonAsync<Dictionary<string, string>>();
        return loginJson!["accessToken"];
    }

    [Fact]
    public async Task Should_Return_NoContent_On_Logout()
    {
        var token = await RegisterAndLoginAsync($"test_{Guid.NewGuid()}@mail.com", "StrongPass123");

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _client.PostAsync("/api/account/logout", null);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}