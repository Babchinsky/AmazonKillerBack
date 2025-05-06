using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using FluentAssertions;

namespace AmazonKiller.IntegrationTests.Auth;

public static class TestAuthHelper
{
    public static async Task<HttpClient> RegisterAndLoginAsync(CustomWebApplicationFactory factory)
    {
        var client = factory.CreateClient();
        var email = $"test_{Guid.NewGuid()}@mail.com";
        const string password = "StrongPass123";

        await client.PostAsJsonAsync("/api/auth/start-registration", new { Email = email, Password = password });
        await client.PostAsJsonAsync("/api/auth/confirm-registration", new { Email = email, Code = "123456" });

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

        await client.PostAsJsonAsync("/api/auth/start-registration", new { Email = email, Password = password });
        await client.PostAsJsonAsync("/api/auth/confirm-registration", new { Email = email, Code = "123456" });

        var loginResponse = await client.PostAsJsonAsync("/api/auth/login", new { Email = email, Password = password });
        var loginJson = await loginResponse.Content.ReadFromJsonAsync<Dictionary<string, string>>();

        var accessToken = loginJson!["accessToken"];

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        return (client, email, password);
    }

    // В классе TestAuthHelper добавьте метод для получения токена
    // Этот метод уже включает регистрацию и получение токена
    public static async Task<string> GetAccessTokenAsync(CustomWebApplicationFactory factory)
    {
        var client = factory.CreateClient();
        var email = $"test_{Guid.NewGuid()}@mail.com";
        const string password = "StrongPass123";

        // Регистрация
        var startBody = new { Email = email, Password = password };
        var startResponse = await client.PostAsJsonAsync("/api/auth/start-registration", startBody);
        if (startResponse.StatusCode != HttpStatusCode.NoContent) throw new Exception("Registration failed");

        // Подтверждение регистрации
        var confirmBody = new { Email = email, Code = "123456" };
        var confirmResponse = await client.PostAsJsonAsync("/api/auth/confirm-registration", confirmBody);
        if (confirmResponse.StatusCode != HttpStatusCode.NoContent)
            throw new Exception("Registration confirmation failed");

        // Логин и получение токена
        var loginResponse = await client.PostAsJsonAsync("/api/auth/login", new { Email = email, Password = password });
        if (loginResponse.StatusCode != HttpStatusCode.OK) throw new Exception("Login failed");

        var loginJson = await loginResponse.Content.ReadFromJsonAsync<Dictionary<string, string>>();
        return loginJson!["accessToken"];
    }
}