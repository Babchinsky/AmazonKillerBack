using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.IntegrationTests.Auth.Registration;

public class StartRegistrationTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    private async Task<HttpResponseMessage> PostAsync(object body)
    {
        return await _client.PostAsJsonAsync("/api/auth/start-registration", body);
    }

    [Fact]
    public async Task Should_Return_NoContent_When_Valid()
    {
        var body = new
        {
            Email = $"test_{Guid.NewGuid()}@mail.com",
            Password = "StrongPass123"
        };

        var response = await PostAsync(body);

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task Should_Return_BadRequest_When_Email_Invalid()
    {
        var body = new
        {
            Email = "invalid-email",
            Password = "StrongPass123"
        };

        var response = await PostAsync(body);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        var problem = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
        Assert.Contains("Email", problem!.Errors.Keys);
    }

    [Fact]
    public async Task Should_Return_BadRequest_When_Email_Missing()
    {
        var body = new
        {
            Password = "StrongPass123"
        };

        var response = await PostAsync(body);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        var problem = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
        Assert.Contains("Email", problem!.Errors.Keys);
    }

    [Fact]
    public async Task Should_Return_BadRequest_When_Password_Too_Short()
    {
        var body = new
        {
            Email = $"test_{Guid.NewGuid()}@mail.com",
            Password = "123"
        };

        var response = await PostAsync(body);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        var problem = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
        Assert.Contains("Password", problem!.Errors.Keys);
    }
}