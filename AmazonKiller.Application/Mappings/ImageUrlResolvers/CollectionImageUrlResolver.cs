using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.DTOs.Collections;
using AmazonKiller.Domain.Entities.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Mappings.ImageUrlResolvers;

public sealed class CollectionImageUrlResolver(IHttpContextAccessor ctx)
    : IValueResolver<Collection, CollectionCardDto, string?>
{
    public string? Resolve(Collection src, CollectionCardDto _, string? __, ResolutionContext ___)
    {
        return string.IsNullOrWhiteSpace(src.ImageUrl)
            ? null
            : ImageUrlHelper.ToAbsoluteUrl(src.ImageUrl, ctx.HttpContext?.Request);
    }
}