using AmazonKiller.Application.DTOs.Cart;
using AmazonKiller.Application.Mappings.ImageUrlResolvers;
using AmazonKiller.Domain.Entities.Users;
using AutoMapper;

namespace AmazonKiller.Application.Mappings;

public class CartMappingProfile : Profile
{
    public CartMappingProfile()
    {
        CreateMap<CartList, CartItemDto>()
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dst => dst.ImageUrl, opt => opt.MapFrom<CartItemImageUrlResolver>())
            .ForMember(dst => dst.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dst => dst.ProductId, opt => opt.MapFrom(src => src.ProductId));
    }
}