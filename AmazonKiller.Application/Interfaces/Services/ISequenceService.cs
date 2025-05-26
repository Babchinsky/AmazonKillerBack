namespace AmazonKiller.Application.Interfaces.Services;

public interface ISequenceService
{
    Task<int> GetNextAsync(string name, CancellationToken ct = default);
}