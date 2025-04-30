using System.Net;
using System.Net.Http.Json;
using AmazonKiller.IntegrationTests.Auth;

namespace AmazonKiller.IntegrationTests.Account.ChangeEmail;

public class EmailChangeStartTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = TestAuthHelper.RegisterAndLoginAsync(factory).Result;

    [Fact]
    public async Task Should_Return_NoContent_For_ValidRequest()
    {
        var body = new { NewEmail = $"new_{Guid.NewGuid()}@mail.com" };
        var response = await _client.PostAsJsonAsync("/api/account/email-change/start", body);
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task Should_Return_BadRequest_For_InvalidEmail()
    {
        var body = new { NewEmail = "bad-email" };
        var response = await _client.PostAsJsonAsync("/api/account/email-change/start", body);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Should_Return_BadRequest_When_Email_Missing()
    {
        var response = await _client.PostAsJsonAsync("/api/account/email-change/start", new { });
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}