using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Common.Helpers;

public static class ImageUrlHelper
{
    public static string ToAbsoluteUrl(string relUrl, HttpRequest? req)
    {
        if (string.IsNullOrWhiteSpace(relUrl) || req is null)
            return relUrl;

        return relUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase)
            ? relUrl
            : $"{req.Scheme}://{req.Host}/uploads/{relUrl.TrimStart('/')}";
    }
}