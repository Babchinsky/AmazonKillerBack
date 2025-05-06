using System.Net;
using System.Net.Http.Json;
using AmazonKiller.IntegrationTests.Auth;

namespace AmazonKiller.IntegrationTests.Account;

public class ChangeNameTests(CustomWebApplicationFactory factory)
    : IClassFixture<CustomWebApplicationFactory>, IAsyncLifetime
{
    private HttpClient? _client;

    public async Task InitializeAsync()
    {
        _client = await TestAuthHelper.RegisterAndLoginAsync(factory);
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    [Fact]
    public async Task Should_Return_NoContent_For_ValidName()
    {
        // Параметры для изменения имени
        var body = new { FirstName = "NewFirstName", LastName = "NewLastName" };

        // Проверка, что _client корректно инициализирован
        Assert.NotNull(_client);

        // Отправка запроса на изменение имени
        var response = await _client!.PutAsJsonAsync("/api/account/name", body);

        // Проверка, что статус код NoContent (204)
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task Should_Return_BadRequest_When_Name_Unchanged()
    {
        // Тест на случай, когда имя не изменяется
        var body = new { FirstName = "OldFirstName", LastName = "OldLastName" };

        // Отправляем запрос на изменение имени
        var response = await _client!.PutAsJsonAsync("/api/account/name", body);

        // Ожидаем BadRequest, так как имя не изменилось
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Should_Return_BadRequest_When_Name_Is_Empty()
    {
        // Тест на случай, когда имя пустое
        var body = new { FirstName = "", LastName = "NewLastName" };

        var response = await _client!.PutAsJsonAsync("/api/account/name", body);

        // Ожидаем BadRequest из-за пустого имени
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}