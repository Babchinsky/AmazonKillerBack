using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Mappings.ImageUrlResolvers.Products;

public sealed class ProductTupleImageUrlResolver(IHttpContextAccessor ctx)
    : IValueResolver<(Product product, int quantity), object, string>
{
    public string Resolve((Product product, int quantity) src, object _, string __, ResolutionContext ___)
    {
        return ImageUrlHelper.ToAbsoluteUrl(src.product.MainImageUrl, ctx.HttpContext?.Request);
    }
}