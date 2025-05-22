using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Domain.Entities.Categories;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Mappings.ImageUrlResolvers;

/// <summary>
/// «2025/05/abc.jpg» → «https://host/uploads/2025/05/abc.jpg».
/// </summary>
public sealed class CategoryImageUrlResolver(IHttpContextAccessor ctx)
    : IValueResolver<Category, CategoryDto, string?>
{
    public string? Resolve(Category src, CategoryDto _, string? __, ResolutionContext ___)
    {
        if (string.IsNullOrWhiteSpace(src.ImageUrl)) return null;

        var req = ctx.HttpContext!.Request;
        var baseUrl = $"{req.Scheme}://{req.Host}/uploads/";

        return src.ImageUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase)
            ? src.ImageUrl
            : baseUrl + src.ImageUrl.TrimStart('/');
    }
}