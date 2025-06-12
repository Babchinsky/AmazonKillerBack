using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.DTOs.Cart;
using AmazonKiller.Domain.Entities.Users;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace AmazonKiller.Application.Mappings.ImageUrlResolvers;

public sealed class CartItemImageUrlResolver(IHttpContextAccessor ctx, IHostEnvironment env)
    : IValueResolver<CartList, CartItemDto, string>
{
    public string Resolve(CartList src, CartItemDto _, string __, ResolutionContext ___)
    {
        return ImageUrlHelper.ToAbsoluteUrl(src.Product.MainImageUrl, ctx.HttpContext?.Request, env) ?? string.Empty;
    }
}