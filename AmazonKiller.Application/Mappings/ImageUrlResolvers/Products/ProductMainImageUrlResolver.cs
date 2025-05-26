using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Mappings.ImageUrlResolvers.Products;

public sealed class ProductMainImageUrlResolver(IHttpContextAccessor ctx)
    : IValueResolver<Product, object, string>
{
    public string Resolve(Product src, object _, string __, ResolutionContext ___)
    {
        return ImageUrlHelper.ToAbsoluteUrl(src.MainImageUrl, ctx.HttpContext?.Request);
    }
}