using AmazonKiller.Application.DTOs.Account.Orders;
using AmazonKiller.Application.Mappings.ImageUrlResolvers;
using AmazonKiller.Domain.Entities.Orders;
using AutoMapper;

namespace AmazonKiller.Application.Mappings;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.OrderedAt, opt => opt.MapFrom(src => src.Info.OrderedAt))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Info.Delivery.Email)); 

        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<OrderItemImageUrlResolver>())
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name));
    }
}