using AmazonKiller.Application.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;

namespace AmazonKiller.Infrastructure.Services.FileStorage;

public class LocalFileStorage(IWebHostEnvironment env) : IFileStorage
{
    private readonly string _root = Path.Combine(
        env.WebRootPath ?? throw new InvalidOperationException("WebRootPath is not configured"),
        "uploads"
    );

    private string GetAbsolutePath(string relativePath)
        => Path.Combine(_root, relativePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));

    public async Task<string> SaveAsync(Stream source, string extension, CancellationToken ct = default)
    {
        var fileName = $"{Guid.NewGuid():N}{extension}";
        var folder = DateTime.UtcNow.ToString("yyyy/MM");
        var dir = Path.Combine(_root, folder);

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        var absPath = Path.Combine(dir, fileName);

        await using var dst = File.Create(absPath);
        await source.CopyToAsync(dst, ct);

        return Path.Combine("uploads", folder, fileName).Replace(Path.DirectorySeparatorChar, '/');
    }

    public Task DeleteAsync(string url, CancellationToken ct = default)
    {
        var path = GetAbsolutePath(url);
        if (File.Exists(path)) File.Delete(path);
        return Task.CompletedTask;
    }

    public Task<bool> ExistsAsync(string url, CancellationToken ct = default)
    {
        var path = GetAbsolutePath(url);
        return Task.FromResult(File.Exists(path));
    }
}