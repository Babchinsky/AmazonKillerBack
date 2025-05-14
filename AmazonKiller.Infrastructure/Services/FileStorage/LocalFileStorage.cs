using AmazonKiller.Application.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;

namespace AmazonKiller.Infrastructure.Services.FileStorage;

public class LocalFileStorage(IWebHostEnvironment env) : IFileStorage
{
    private readonly string _root = Path.Combine(env.ContentRootPath, "wwwroot", "uploads");

    public async Task<string> SaveAsync(Stream source, string extension, CancellationToken ct = default)
    {
        var fileName = Guid.NewGuid() + extension;
        var folder = DateTime.UtcNow.ToString("yyyy/MM"); // uploads/2025/05
        var dir = Path.Combine(_root, folder);
        Directory.CreateDirectory(dir);

        var absPath = Path.Combine(dir, fileName);
        await using var dst = new FileStream(absPath, FileMode.Create);
        await source.CopyToAsync(dst, ct);

        return $"/uploads/{folder}/{fileName}"; // публичный URL
    }

    public Task DeleteAsync(string url, CancellationToken ct = default)
    {
        var localPath = Path.Combine(_root, url.TrimStart('/'));
        if (File.Exists(localPath))
            File.Delete(localPath);

        return Task.CompletedTask;
    }
}