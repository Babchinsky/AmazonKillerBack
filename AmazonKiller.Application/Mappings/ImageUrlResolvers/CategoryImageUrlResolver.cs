using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Domain.Entities.Categories;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Mappings.ImageUrlResolvers;

public sealed class CategoryImageUrlResolver(IHttpContextAccessor ctx)
    : IValueResolver<Category, CategoryDto, string?>
{
    public string? Resolve(Category src, CategoryDto _, string? __, ResolutionContext ___)
    {
        return string.IsNullOrWhiteSpace(src.ImageUrl)
            ? null
            : ImageUrlHelper.ToAbsoluteUrl(src.ImageUrl, ctx.HttpContext?.Request);
    }
}