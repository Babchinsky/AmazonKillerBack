using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace AmazonKiller.Application.Common.Helpers;

public static class ImageUrlHelper
{
    private static bool IsAbsoluteUrl(string url)
    {
        return url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
               url.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ||
               url.StartsWith("data:", StringComparison.OrdinalIgnoreCase); // for base64
    }

    public static string ToAbsoluteUrl(string relUrl, HttpRequest? req, IHostEnvironment? env = null)
    {
        if (string.IsNullOrWhiteSpace(relUrl))
            return string.Empty;

        if (IsAbsoluteUrl(relUrl) || req is null)
            return relUrl;

        // ⚠️ Добавим префикс "/uploads/" если его нет
        var relativePath = relUrl.StartsWith("uploads/")
            ? relUrl
            : $"uploads/{relUrl.TrimStart('/')}";

        // If Development, prepend local uploads path
        return env?.IsDevelopment() == true
            ? $"{req.Scheme}://{req.Host}/{relativePath}"
            : relativePath; // в проде пусть остаётся относительным или уже Azure URL
    }
}