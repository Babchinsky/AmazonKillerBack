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
public sealed class LocalFileStorage(IWebHostEnvironment env, ILogger<LocalFileStorage> log) : IFileStorage
{
    private string WebRoot => env.WebRootPath ?? throw new InvalidOperationException("WebRootPath is not configured");
    private string UploadRoot => Path.Combine(WebRoot, "uploads"); // …/wwwroot/uploads

    /* ──────────────────────────  SAVE  ────────────────────────────── */

    public async Task<string> SaveAsync(Stream src, string ext, CancellationToken ct = default)
    {
        var folder = DateTime.UtcNow.ToString("yyyy/MM"); // 2025/05
        var fileName = $"{Guid.NewGuid():N}{ext}"; // <guid>.jpg
        var dir = Path.Combine(UploadRoot, folder); // …/uploads/2025/05
        Directory.CreateDirectory(dir);

        var absPath = Path.Combine(dir, fileName);
        await using var dst = File.Create(absPath);
        await src.CopyToAsync(dst, ct);

        // 👇 только 2025/05/<guid>.jpg
        return Path.Combine(folder, fileName).Replace('\\', '/');
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
            try
            {
                await DeleteAsync(u, ct);
            }
            catch (Exception ex)
            {
                log.LogWarning(ex, "Failed to delete file {File}", u);
            }
    }
}