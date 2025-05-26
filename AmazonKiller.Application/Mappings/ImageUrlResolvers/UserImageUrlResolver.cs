using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Domain.Entities.Reviews;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Mappings.ImageUrlResolvers;

public sealed class UserImageUrlResolver(IHttpContextAccessor ctx)
    : IValueResolver<Review, ReviewDto, string>
{
    public string Resolve(Review src, ReviewDto _, string __, ResolutionContext ___)
    {
        return string.IsNullOrWhiteSpace(src.User.ImageUrl)
            ? string.Empty
            : ImageUrlHelper.ToAbsoluteUrl(src.User.ImageUrl, ctx.HttpContext?.Request);
    }
}