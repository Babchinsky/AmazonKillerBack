namespace AmazonKiller.Application.Interfaces.Common.Address;

public interface ICountryService
{
    Task<List<string>> GetCountriesAsync(CancellationToken ct);
}
