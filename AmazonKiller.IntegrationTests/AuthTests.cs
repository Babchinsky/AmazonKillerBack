using System.Net;
using System.Net.Http.Json;

namespace AmazonKiller.IntegrationTests;

public class AuthTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task StartRegistration_ShouldReturn_NoContent()
    {
        var body = new
        {
            Email = $"test_{Guid.NewGuid()}@mail.com",
            FirstName = "Test",
            LastName = "User",
            Password = "StrongPass123"
        };

        var response = await _client.PostAsJsonAsync("/api/auth/start-registration", body);

        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Unexpected status code {response.StatusCode}. Response content: {errorContent}");
        }

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

}