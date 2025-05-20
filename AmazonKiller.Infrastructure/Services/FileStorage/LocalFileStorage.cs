using AmazonKiller.Application.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace AmazonKiller.Infrastructure.Services.FileStorage;

public sealed class LocalFileStorage(
    IWebHostEnvironment env,
    ILogger<LocalFileStorage> log) : IFileStorage
{
    // …/wwwroot/uploads
    private readonly string _root = Path.Combine(
        env.WebRootPath
        ?? throw new InvalidOperationException("WebRootPath is not configured"),
        "uploads");

    /* ---------- Сохранить файл --------------------------------------- */
    public async Task<string> SaveAsync(Stream src,
        string ext,
        CancellationToken ct = default)
    {
        var file = $"{Guid.NewGuid():N}{ext}";
        var folder = DateTime.UtcNow.ToString("yyyy/MM"); // 2025/05
        var dir = Path.Combine(_root, folder); // …\uploads\2025\05

        Directory.CreateDirectory(dir); // идемпотентно

        await using var dst = File.Create(Path.Combine(dir, file));
        await src.CopyToAsync(dst, ct);

        // ►  uploads/2025/05/<guid>.jpg  – то, что пойдёт в БД
        return Path.Combine("uploads", folder, file)
            .Replace(Path.DirectorySeparatorChar, '/');
    }

    /* ---------- Удалить один / пачку ---------------------------------- */
    private string Abs(string urlRel)
    {
        return Path.Combine(_root,
            urlRel.TrimStart('/')
                .Replace('/', Path.DirectorySeparatorChar));
    }

    public Task DeleteAsync(string url, CancellationToken _ = default)
    {
        var abs = Abs(url);
        if (File.Exists(abs)) File.Delete(abs);
        return Task.CompletedTask;
    }

    public async Task DeleteBatchSafeAsync(IEnumerable<string> urls,
        CancellationToken ct = default)
    {
        foreach (var u in urls)
            try
            {
                await DeleteAsync(u, ct);
            }
            catch (Exception ex)
            {
                log.LogWarning(ex, "Can't delete {u}", u);
            }
    }
}