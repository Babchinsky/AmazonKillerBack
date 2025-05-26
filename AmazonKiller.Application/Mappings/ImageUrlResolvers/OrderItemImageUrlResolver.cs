using AmazonKiller.Application.DTOs.Account.Orders;
using AmazonKiller.Domain.Entities.Orders;
using AmazonKiller.Application.Common.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Mappings.ImageUrlResolvers;

public sealed class OrderItemImageUrlResolver(IHttpContextAccessor ctx)
    : IValueResolver<OrderItem, OrderItemDto, string?>
{
    public string? Resolve(OrderItem src, OrderItemDto _, string? __, ResolutionContext ___)
    {
        return ImageUrlHelper.ToAbsoluteUrl(src.Product.MainImageUrl, ctx.HttpContext?.Request);
    }
}