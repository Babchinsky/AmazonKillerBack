using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Domain.Entities.Reviews;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace AmazonKiller.Application.Mappings.ImageUrlResolvers;

public sealed class ReviewImageUrlResolver(IHttpContextAccessor ctx, IHostEnvironment env)
    : IValueResolver<Review, ReviewDto, List<string>>
{
    public List<string> Resolve(Review src, ReviewDto _, List<string> __, ResolutionContext ___)
    {
        var req = ctx.HttpContext?.Request;
        return src.ImageUrls.Select(url => ImageUrlHelper.ToAbsoluteUrl(url, req, env)).ToList();
    }
}