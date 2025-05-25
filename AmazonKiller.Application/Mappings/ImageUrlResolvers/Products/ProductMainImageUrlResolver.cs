using AmazonKiller.Domain.Entities.Products;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Mappings.ImageUrlResolvers.Products;

public sealed class ProductMainImageUrlResolver(IHttpContextAccessor ctx)
    : IValueResolver<Product, object, string>
{
    public string Resolve(Product src, object _, string __, ResolutionContext ___)
    {
        var req = ctx.HttpContext!.Request;
        var baseUrl = $"{req.Scheme}://{req.Host}/uploads/";

        var image = src.MainImageUrl;
        return image.StartsWith("http", StringComparison.OrdinalIgnoreCase)
            ? image
            : baseUrl + image;
    }
}