using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace AmazonKiller.Application.Mappings.ImageUrlResolvers.Products;

public sealed class ProductMainImageUrlResolver(IHttpContextAccessor ctx, IHostEnvironment env)
    : IValueResolver<Product, object, string>
{
    public string Resolve(Product src, object _, string __, ResolutionContext ___)
    {
        return ImageUrlHelper.ToAbsoluteUrl(src.MainImageUrl, ctx.HttpContext?.Request, env);
    }
}