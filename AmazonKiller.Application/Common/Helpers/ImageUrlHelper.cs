using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace AmazonKiller.Application.Common.Helpers;

public static class ImageUrlHelper
{
    private static bool IsAbsoluteUrl(string url)
    {
        return url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
               url.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ||
               url.StartsWith("data:", StringComparison.OrdinalIgnoreCase); // для base64
    }

    public static string ToAbsoluteUrl(string relUrl, HttpRequest? req, IHostEnvironment? env = null)
    {
        if (string.IsNullOrWhiteSpace(relUrl))
            return string.Empty;

        // already absolute (http, https, data:) — return as is
        if (IsAbsoluteUrl(relUrl))
            return relUrl;

        // if no request (e.g., background service) — return relative path
        if (req is null)
            return relUrl;

        // If Development, prepend local uploads path
        return env?.IsDevelopment() == true
            ? $"{req.Scheme}://{req.Host}/uploads/{relUrl.TrimStart('/')}"
            : relUrl; // In Production — assume relUrl is already correct
    }
}