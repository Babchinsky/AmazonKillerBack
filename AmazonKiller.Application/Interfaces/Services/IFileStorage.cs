namespace AmazonKiller.Application.Interfaces.Services;

public interface IFileStorage
{
    Task<string> SaveAsync(Stream source, string extension, CancellationToken ct = default);
    Task DeleteAsync(string url, CancellationToken ct = default);

    // Новый опциональный helper
    Task<bool> ExistsAsync(string url, CancellationToken ct = default)
    {
        return Task.FromResult(false);
    }
}