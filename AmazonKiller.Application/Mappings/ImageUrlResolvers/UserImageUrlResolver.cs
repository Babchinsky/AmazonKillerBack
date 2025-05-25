using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Domain.Entities.Reviews;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Mappings.ImageUrlResolvers;

public class UserImageUrlResolver(IHttpContextAccessor ctx) : IValueResolver<Review, ReviewDto, string>
{
    public string Resolve(Review src, ReviewDto _, string __, ResolutionContext ___)
    {
        var relUrl = src.User.ImageUrl;
        if (string.IsNullOrWhiteSpace(relUrl)) return string.Empty;

        var req = ctx.HttpContext?.Request;
        var baseUrl = $"{req?.Scheme}://{req?.Host}/uploads/";

        return relUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase)
            ? relUrl
            : baseUrl + relUrl.TrimStart('/');
    }
}