using AmazonKiller.Application.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace AmazonKiller.Infrastructure.Services.FileStorage;

/// <summary>
/// Stores files inside <c>wwwroot/uploads/yyyy/MM</c> and returns a relative url
/// in the form <c>uploads/yyyy/MM/{guid}.{ext}</c>.
/// 
/// * Deleting now works correctly because we always build the absolute path
///   off of the <c>wwwroot</c> folder – <strong>not</strong> off of
///   <c>wwwroot/uploads</c>.
/// </summary>
public sealed class LocalFileStorage : IFileStorage
{
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<LocalFileStorage> _log;

    private string WebRoot => _env.WebRootPath ?? throw new InvalidOperationException("WebRootPath is not configured");
    private string UploadRoot => Path.Combine(WebRoot, "uploads"); // …/wwwroot/uploads

    public LocalFileStorage(IWebHostEnvironment env, ILogger<LocalFileStorage> log)
    {
        _env = env;
        _log = log;
    }

    /* ──────────────────────────  SAVE  ────────────────────────────── */

    public async Task<string> SaveAsync(Stream src, string ext, CancellationToken ct = default)
    {
        var folder = DateTime.UtcNow.ToString("yyyy/MM"); // 2025/05
        var fileName = $"{Guid.NewGuid():N}{ext}"; // <guid>.jpg
        var dir = Path.Combine(UploadRoot, folder); // …/wwwroot/uploads/2025/05

        Directory.CreateDirectory(dir);

        var absPath = Path.Combine(dir, fileName);
        await using var dst = File.Create(absPath);
        await src.CopyToAsync(dst, ct);

        // → DB: uploads/2025/05/<guid>.jpg
        return Path.Combine("uploads", folder, fileName).Replace(Path.DirectorySeparatorChar, '/');
    }

    /* ─────────────────────────  DELETE  ───────────────────────────── */

    private string AbsolutePath(string url)
    {
        // url in DB: uploads/2025/05/<guid>.jpg OR 2025/05/<guid>.jpg (both are supported)
        var relative = url.TrimStart('/');
        if (relative.StartsWith("uploads/", StringComparison.OrdinalIgnoreCase))
            relative = relative["uploads/".Length..];

        return Path.Combine(UploadRoot, relative.Replace('/', Path.DirectorySeparatorChar));
    }

    public Task DeleteAsync(string url, CancellationToken ct = default)
    {
        var abs = AbsolutePath(url);
        if (File.Exists(abs)) File.Delete(abs);
        return Task.CompletedTask;
    }

    public async Task DeleteBatchSafeAsync(IEnumerable<string> urls, CancellationToken ct = default)
    {
        foreach (var u in urls.Distinct(StringComparer.OrdinalIgnoreCase))
        {
            try
            {
                await DeleteAsync(u, ct);
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Failed to delete file {File}", u);
            }
        }
    }
}