using System.Net;
using System.Net.Http.Json;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.IntegrationTests.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace AmazonKiller.IntegrationTests.Account.ChangeEmail;

public class EmailChangeConfirmTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public EmailChangeConfirmTests(CustomWebApplicationFactory factory)
    {
        var result = TestAuthHelper.RegisterAndLoginWithCredentialsAsync(factory).Result;
        _client = result.Client;

        // Очистка in-memory базы
        var scope = factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AmazonDbContext>();
        db.EmailVerifications.RemoveRange(db.EmailVerifications);
        db.SaveChanges();
    }

    [Fact]
    public async Task Should_Return_NoContent_For_ValidRequest()
    {
        var newEmail = $"new_{Guid.NewGuid()}@mail.com";

        var startBody = new { NewEmail = newEmail };
        var startResponse = await _client.PostAsJsonAsync("/api/account/email-change/start", startBody);
        Assert.Equal(HttpStatusCode.NoContent, startResponse.StatusCode);

        var confirmBody = new { Email = newEmail, Code = "123456" };
        var confirmResponse = await _client.PostAsJsonAsync("/api/account/email-change/confirm", confirmBody);
        Assert.Equal(HttpStatusCode.NoContent, confirmResponse.StatusCode);
    }

    [Fact]
    public async Task Should_Return_BadRequest_For_InvalidCode()
    {
        var newEmail = $"invalid_{Guid.NewGuid()}@mail.com";

        var startBody = new { NewEmail = newEmail };
        var startResponse = await _client.PostAsJsonAsync("/api/account/email-change/start", startBody);
        Assert.Equal(HttpStatusCode.NoContent, startResponse.StatusCode);

        var confirmBody = new { Email = newEmail, Code = "wrongcode" };
        var response = await _client.PostAsJsonAsync("/api/account/email-change/confirm", confirmBody);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}