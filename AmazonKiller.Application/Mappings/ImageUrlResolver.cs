using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Mappings;

/// <summary>
/// «2025/05/abc.jpg» → «https://host/uploads/2025/05/abc.jpg».
/// </summary>
public sealed class ImageUrlResolver(IHttpContextAccessor ctx)
    : IValueResolver<Product, ProductDto, List<string>>
{
    public List<string> Resolve(
        Product src, ProductDto _, List<string> __, ResolutionContext ___)
    {
        var req = ctx.HttpContext!.Request;
        var baseUrl = $"{req.Scheme}://{req.Host}/uploads/"; // https://host/uploads/

        return src.ImageUrls // 2025/05/abc.jpg
            .Select(rel =>
                rel.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                    ? rel // уже абсолютный
                    : baseUrl + rel) // => https://host/uploads/2025/05/abc.jpg
            .ToList();
    }
}