using AmazonKiller.Domain.Entities.Orders;
using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.DTOs.Orders;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace AmazonKiller.Application.Mappings.ImageUrlResolvers;

public sealed class OrderItemImageUrlResolver(IHttpContextAccessor ctx, IHostEnvironment env)
    : IValueResolver<OrderItem, OrderItemDto, string?>
{
    public string? Resolve(OrderItem src, OrderItemDto _, string? __, ResolutionContext ___)
    {
        return ImageUrlHelper.ToAbsoluteUrl(src.Product.MainImageUrl, ctx.HttpContext?.Request, env);
    }
}