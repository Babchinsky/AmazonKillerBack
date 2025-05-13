using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AmazonKiller.IntegrationTests.Auth;

public class LoginTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    private string? GetFixedCode()
    {
        using var scope = factory.Services.CreateScope();
        var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
        return config.GetValue<string>("Verification:FixedCodeValue");
    }

    private async Task RegisterTestUserAsync(string email, string password)
    {
        // Start registration
        var startBody = new { Email = email, Password = password };
        var startResponse = await _client.PostAsJsonAsync("/api/auth/start-registration", startBody);
        startResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

        // Confirm registration
        var code = GetFixedCode();
        var confirmBody = new { Email = email, Code = code };
        var confirmResponse = await _client.PostAsJsonAsync("/api/auth/confirm-registration", confirmBody);
        confirmResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task Login_ShouldReturn_Token_WhenCredentialsAreValid()
    {
        var email = $"test_{Guid.NewGuid()}@mail.com";
        const string password = "StrongPass123";
        await RegisterTestUserAsync(email, password);

        var body = new { Email = email, Password = password };
        var response = await _client.PostAsJsonAsync("/api/auth/login", body);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var json = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
        json.Should().ContainKey("accessToken");
    }

    [Fact]
    public async Task Login_ShouldReturn_Unauthorized_WhenPasswordInvalid()
    {
        var email = $"test_{Guid.NewGuid()}@mail.com";
        const string password = "StrongPass123";
        await RegisterTestUserAsync(email, password);

        var body = new { Email = email, Password = "WrongPass" };
        var response = await _client.PostAsJsonAsync("/api/auth/login", body);

        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Login_ShouldReturn_BadRequest_WhenEmailMissing()
    {
        var body = new { Password = "StrongPass123" };
        var response = await _client.PostAsJsonAsync("/api/auth/login", body);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Login_ShouldReturn_BadRequest_WhenPasswordMissing()
    {
        var body = new { Email = "test@mail.com" };
        var response = await _client.PostAsJsonAsync("/api/auth/login", body);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}