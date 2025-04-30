using System.Net;
using System.Net.Http.Json;
using FluentAssertions;

namespace AmazonKiller.IntegrationTests.Auth.Registration;

public class ConfirmRegistrationTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task Should_Register_And_Login_Successfully()
    {
        var email = $"test_{Guid.NewGuid()}@mail.com";
        const string password = "StrongPass123";

        // 1. Start registration
        var startBody = new { Email = email, Password = password };
        var startResponse = await _client.PostAsJsonAsync("/api/auth/start-registration", startBody);
        startResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

        // 2. (тестовая заглушка) Вставим фиксированный код (если ты используешь его как `"123456"` на тестах)
        var confirmBody = new { Email = email, Code = "123456" };
        var confirmResponse = await _client.PostAsJsonAsync("/api/auth/confirm-registration", confirmBody);
        confirmResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

        // 3. Проверим логин
        var loginBody = new { Email = email, Password = password };
        var loginResponse = await _client.PostAsJsonAsync("/api/auth/login", loginBody);
        loginResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var json = await loginResponse.Content.ReadFromJsonAsync<Dictionary<string, string>>();
        json.Should().ContainKey("accessToken");
    }
}