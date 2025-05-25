using AmazonKiller.Domain.Entities.Products;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Mappings.ImageUrlResolvers.Products;

public sealed class ProductTupleImageUrlResolver(IHttpContextAccessor ctx)
    : IValueResolver<(Product product, int quantity), object, string>
{
    public string Resolve((Product product, int quantity) src, object _, string __, ResolutionContext ___)
    {
        var req = ctx.HttpContext!.Request;
        var baseUrl = $"{req.Scheme}://{req.Host}/uploads/";

        var image = src.product.MainImageUrl;
        return image.StartsWith("http", StringComparison.OrdinalIgnoreCase)
            ? image
            : baseUrl + image;
    }
}