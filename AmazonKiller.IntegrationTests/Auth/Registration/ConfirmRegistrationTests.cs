using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AmazonKiller.IntegrationTests.Auth.Registration;

public class ConfirmRegistrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly string? _fixedCode;

    public ConfirmRegistrationTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();

        using var scope = factory.Services.CreateScope();
        var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
        _fixedCode = config.GetValue<string>("Verification:FixedCodeValue");
    }

    [Fact]
    public async Task Should_Register_And_Login_Successfully()
    {
        var email = $"test_{Guid.NewGuid()}@mail.com";
        const string password = "StrongPass123";

        // 1. Start registration
        var startBody = new { Email = email, Password = password };
        var startResponse = await _client.PostAsJsonAsync("/api/auth/start-registration", startBody);
        startResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

        // 2. Confirm registration (с фиксированным кодом)
        var confirmBody = new { Email = email, Code = _fixedCode };
        var confirmResponse = await _client.PostAsJsonAsync("/api/auth/confirm-registration", confirmBody);
        confirmResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

        // 3. Login
        var loginBody = new { Email = email, Password = password };
        var loginResponse = await _client.PostAsJsonAsync("/api/auth/login", loginBody);
        loginResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var json = await loginResponse.Content.ReadFromJsonAsync<Dictionary<string, string>>();
        json.Should().ContainKey("accessToken");
    }
}