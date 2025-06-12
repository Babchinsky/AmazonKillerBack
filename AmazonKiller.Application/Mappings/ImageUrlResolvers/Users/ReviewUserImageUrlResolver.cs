using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Domain.Entities.Reviews;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace AmazonKiller.Application.Mappings.ImageUrlResolvers.Users;

public sealed class ReviewUserImageUrlResolver(IHttpContextAccessor ctx, IHostEnvironment env)
    : IValueResolver<Review, ReviewDto, string>
{
    public string Resolve(Review src, ReviewDto _, string __, ResolutionContext ___)
    {
        return string.IsNullOrWhiteSpace(src.User.ImageUrl)
            ? string.Empty
            : ImageUrlHelper.ToAbsoluteUrl(src.User.ImageUrl, ctx.HttpContext?.Request, env);
    }
}