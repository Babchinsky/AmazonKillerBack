// Application/Interfaces/Common/IFileStorage.cs

namespace AmazonKiller.Application.Interfaces.Services;

public interface IFileStorage
{
    /// <summary>Сохраняет файл и возвращает публичный URL.</summary>
    Task<string> SaveAsync(
        Stream source,
        string extension,
        CancellationToken ct = default);

    Task DeleteAsync(string url, CancellationToken ct = default);
}