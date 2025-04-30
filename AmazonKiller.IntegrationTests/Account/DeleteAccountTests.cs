using System.Net;
using AmazonKiller.IntegrationTests.Auth;

namespace AmazonKiller.IntegrationTests.Account;

public class DeleteAccountTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = TestAuthHelper.RegisterAndLoginAsync(factory).Result;

    [Fact]
    public async Task Should_Return_NoContent_On_Delete()
    {
        var response = await _client.DeleteAsync("/api/account");
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}