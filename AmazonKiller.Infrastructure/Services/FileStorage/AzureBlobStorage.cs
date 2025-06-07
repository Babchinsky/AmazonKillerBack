using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Application.Options;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;

namespace AmazonKiller.Infrastructure.Services.FileStorage;

public class AzureBlobStorage(IOptions<BlobStorageOptions> options) : IFileStorage
{
    private readonly BlobContainerClient _container = new(
        options.Value.ConnectionString,
        options.Value.ContainerName);

    private static string GetContentType(string ext)
    {
        return ext.ToLower() switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".webp" => "image/webp",
            ".bmp" => "image/bmp",
            ".svg" => "image/svg+xml",
            _ => "application/octet-stream"
        };
    }

    public async Task<string> SaveAsync(Stream src, string ext, CancellationToken ct = default)
    {
        var blobName = $"{DateTime.UtcNow:yyyy/MM}/{Guid.NewGuid():N}{ext}";
        var blob = _container.GetBlobClient(blobName);

        var headers = new Azure.Storage.Blobs.Models.BlobHttpHeaders
        {
            ContentType = GetContentType(ext) // установить правильный тип
            // Не указываем Content-Disposition → браузер сам решит, как открыть
        };

        await blob.UploadAsync(src, new Azure.Storage.Blobs.Models.BlobUploadOptions
        {
            HttpHeaders = headers
        }, ct);

        return blob.Uri.ToString();
    }

    public async Task DeleteAsync(string url, CancellationToken ct = default)
    {
        var blob = _container.GetBlobClient(url);
        await blob.DeleteIfExistsAsync(cancellationToken: ct);
    }

    public async Task DeleteBatchSafeAsync(List<string> urls, CancellationToken ct = default)
    {
        foreach (var url in urls.Distinct(StringComparer.OrdinalIgnoreCase))
            try
            {
                await DeleteAsync(url, ct);
            }
            catch
            {
                /* log if needed */
            }
    }
}