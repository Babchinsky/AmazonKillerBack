using AmazonKiller.Application.DTOs.Account.Wishlist;
using AmazonKiller.Domain.Entities.Users;
using AutoMapper;

namespace AmazonKiller.Application.Mappings;

public class WishlistMappingProfile : Profile
{
    public WishlistMappingProfile()
    {
        CreateMap<Wishlist, ProductInWishlistDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Product.Id))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom(src => src.Product.ProductPics.FirstOrDefault() ?? ""))
            .ForMember(dest => dest.Price,
                opt => opt.MapFrom(src => src.Product.Price))
            .ForMember(dest => dest.OldPrice,
                opt => opt.MapFrom(src =>
                    src.Product.DiscountPct.HasValue
                        ? (decimal?)Math.Round(src.Product.Price / (1 - (src.Product.DiscountPct.Value / 100)), 2)
                        : null))
            .ForMember(dest => dest.Rating,
                opt => opt.MapFrom(src => (double)src.Product.Rating))
            .ForMember(dest => dest.ReviewsCount,
                opt => opt.MapFrom(src => src.Product.ReviewsCount))
            .ForMember(dest => dest.AddedAt,
                opt => opt.MapFrom(src => src.AddedAt));
    }
}