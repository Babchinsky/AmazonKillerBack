using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace AmazonKiller.Application.Mappings.ImageUrlResolvers.Products;

public sealed class ProductImageUrlResolver(IHttpContextAccessor ctx, IHostEnvironment env)
    : IValueResolver<Product, ProductDto, List<string>>
{
    public List<string> Resolve(Product src, ProductDto _, List<string> __, ResolutionContext ___)
    {
        var req = ctx.HttpContext?.Request;
        return src.ImageUrls.Select(url => ImageUrlHelper.ToAbsoluteUrl(url, req, env)).ToList();
    }
}