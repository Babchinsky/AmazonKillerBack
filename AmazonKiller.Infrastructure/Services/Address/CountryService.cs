using AmazonKiller.Application.Interfaces.Services.Address;

namespace AmazonKiller.Infrastructure.Services.Address;

public class CountryService : ICountryService
{
    public Task<List<string>> GetCountriesAsync(CancellationToken ct)
    {
        return Task.FromResult(new List<string> { "Україна" });
    }
}