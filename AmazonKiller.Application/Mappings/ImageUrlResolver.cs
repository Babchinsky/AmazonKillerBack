using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Mappings;

/// <summary>
/// «uploads/2025/05/abc.jpg» → «http(s)://host/uploads/2025/05/abc.jpg»
/// </summary>
public sealed class ImageUrlResolver(IHttpContextAccessor ctx) :
    IValueResolver<Product, ProductDto, List<string>>
{
    public List<string> Resolve(
        Product src,
        ProductDto _,
        List<string> __,
        ResolutionContext ___)
    {
        var http = ctx.HttpContext;

        // если резолвер вызвали вне HTTP-контекста (тест / background-job)
        if (http is null)
            return src.ImageUrls.ToList();

        var baseUrl = $"{http.Request.Scheme}://{http.Request.Host}";
        return src.ImageUrls
            .Select(u => $"{baseUrl}/{u.TrimStart('/')}")
            .ToList();
    }
}