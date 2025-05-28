using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.DTOs.Users;
using AmazonKiller.Domain.Entities.Users;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Mappings.ImageUrlResolvers.Users;

public sealed class UserImageUrlResolver(IHttpContextAccessor ctx)
    : IValueResolver<User, UserInfoDto, string?>
{
    public string? Resolve(User src, UserInfoDto _, string? __, ResolutionContext ___)
    {
        return string.IsNullOrWhiteSpace(src.ImageUrl)
            ? string.Empty
            : ImageUrlHelper.ToAbsoluteUrl(src.ImageUrl, ctx.HttpContext?.Request);
    }
}