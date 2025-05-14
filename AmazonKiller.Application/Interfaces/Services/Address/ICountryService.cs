namespace AmazonKiller.Application.Interfaces.Services.Address;

public interface ICountryService
{
    Task<List<string>> GetCountriesAsync(CancellationToken ct);
}