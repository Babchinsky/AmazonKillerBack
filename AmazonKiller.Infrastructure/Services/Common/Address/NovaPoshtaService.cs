using System.Text;
using System.Text.Json;
using AmazonKiller.Application.DTOs.Common.Address;
using AmazonKiller.Application.Interfaces.Common.Address;
using AmazonKiller.Application.Options;
using Microsoft.Extensions.Options;

namespace AmazonKiller.Infrastructure.Services.Common.Address;

public class NovaPoshtaService(HttpClient client, IOptions<NovaPoshtaOptions> options) : INovaPoshtaService
{
    private readonly string _apiKey = options.Value.ApiKey;
    private readonly string _baseUrl = options.Value.ApiUrl;

    public async Task<List<string>> GetRegionsAsync(CancellationToken ct)
    {
        var payload = new
        {
            apiKey = _apiKey,
            modelName = "Address",
            calledMethod = "getAreas"
        };

        var response = await PostAsync(payload, ct);
        return response?.GetProperty("data").EnumerateArray()
            .Select(x => x.GetProperty("Description").GetString()!)
            .ToList() ?? [];
    }

    public async Task<List<CityDto>> GetCitiesAsync(string region, CancellationToken ct)
    {
        var payload = new
        {
            apiKey = _apiKey,
            modelName = "Address",
            calledMethod = "getCities"
        };

        var response = await PostAsync(payload, ct);
        return response?.GetProperty("data").EnumerateArray()
            .Where(x => x.GetProperty("AreaDescription").GetString() == region)
            .Select(x => new CityDto
            {
                Description = x.GetProperty("Description").GetString()!,
                Ref = x.GetProperty("Ref").GetString()!
            })
            .ToList() ?? [];
    }

    private async Task<JsonElement?> PostAsync(object payload, CancellationToken ct)
    {
        var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
        var response = await client.PostAsync(_baseUrl, content, ct);

        if (!response.IsSuccessStatusCode)
            return null;

        var stream = await response.Content.ReadAsStreamAsync(ct);
        var json = await JsonSerializer.DeserializeAsync<JsonElement>(stream, cancellationToken: ct);
        return json;
    }
}