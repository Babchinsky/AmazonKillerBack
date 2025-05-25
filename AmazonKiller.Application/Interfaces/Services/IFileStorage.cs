namespace AmazonKiller.Application.Interfaces.Services;

public interface IFileStorage
{
    Task<string> SaveAsync(Stream src, string ext, CancellationToken ct = default);
    Task DeleteAsync(string url, CancellationToken ct = default);

    /// <summary>Удалить сразу несколько объектов «мягко» (ошибки – в лог).</summary>
    Task DeleteBatchSafeAsync(List<string> urls,
        CancellationToken ct = default);
}