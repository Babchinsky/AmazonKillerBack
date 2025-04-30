using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using AmazonKiller.IntegrationTests.Auth;
using Xunit.Abstractions;

namespace AmazonKiller.IntegrationTests.Account;

public class ChangePasswordTests(CustomWebApplicationFactory factory, ITestOutputHelper testOutputHelper) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = TestAuthHelper.RegisterAndLoginAsync(factory).Result;
    
    [Fact]
    public async Task Should_Return_NoContent_For_ValidPasswordChange()
    {
        var body = new { CurrentPassword = "OldPass123", NewPassword = "NewPass456" };

        // Получаем токен авторизации и добавляем его в заголовок запроса
        var accessToken = await TestAuthHelper.GetAccessTokenAsync(factory);
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        // Логирование для проверки, что токен добавлен
        testOutputHelper.WriteLine($"Authorization Token: {accessToken}");

        var response = await _client.PutAsJsonAsync("/api/account/password", body);

        // Проверяем, что ответ соответствует ожиданиям
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }


    [Fact]
    public async Task Should_Return_BadRequest_When_CurrentPassword_Missing()
    {
        var body = new { NewPassword = "NewPass456" };

        // Получаем токен авторизации и добавляем его в заголовок запроса
        var accessToken = await TestAuthHelper.GetAccessTokenAsync(factory);
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        // Отправляем запрос без текущего пароля
        var response = await _client.PutAsJsonAsync("/api/account/password", body);

        // Проверяем, что сервер вернул ошибку BadRequest
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}