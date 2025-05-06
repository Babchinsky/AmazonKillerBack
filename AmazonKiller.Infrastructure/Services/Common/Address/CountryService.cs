using AmazonKiller.Application.Interfaces.Common.Address;

namespace AmazonKiller.Infrastructure.Services.Common.Address;

public class CountryService : ICountryService
{
    public Task<List<string>> GetCountriesAsync(CancellationToken ct)
    {
        return Task.FromResult(new List<string> { "Україна" });
    }
}