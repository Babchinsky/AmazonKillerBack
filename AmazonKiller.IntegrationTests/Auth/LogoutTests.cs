using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using FluentAssertions;

namespace AmazonKiller.IntegrationTests.Auth;

public class LogoutTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = TestAuthHelper.RegisterAndLoginAsync(factory).Result;

    private async Task<string> RegisterAndLoginAsync()
    {
        var email = $"test_{Guid.NewGuid()}@mail.com";
        const string password = "StrongPass123";

        // Start registration
        await _client.PostAsJsonAsync("/api/auth/start-registration", new { Email = email, Password = password });

        // Confirm registration
        await _client.PostAsJsonAsync("/api/auth/confirm-registration", new { Email = email, Code = "123456" });

        // Login
        var loginResponse =
            await _client.PostAsJsonAsync("/api/auth/login", new { Email = email, Password = password });
        var loginJson = await loginResponse.Content.ReadFromJsonAsync<Dictionary<string, string>>();

        return loginJson!["accessToken"];
    }

    [Fact]
    public async Task Should_Return_NoContent_On_Logout()
    {
        var token = await RegisterAndLoginAsync();

        // Добавляем токен в заголовок
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _client.PostAsync("/api/account/logout", null);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}