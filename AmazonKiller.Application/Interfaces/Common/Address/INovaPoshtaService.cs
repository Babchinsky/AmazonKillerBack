using AmazonKiller.Application.DTOs.Common.Address;

namespace AmazonKiller.Application.Interfaces.Common.Address;

public interface INovaPoshtaService
{
    Task<List<string>> GetRegionsAsync(CancellationToken ct);
    Task<List<CityDto>> GetCitiesAsync(string region, CancellationToken ct);
}