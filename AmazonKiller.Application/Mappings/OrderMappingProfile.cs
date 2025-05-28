using AmazonKiller.Application.DTOs.Orders;
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
            .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.OrderNumber))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.DeliveryEmail, opt => opt.MapFrom(src => src.Info.Delivery.Email))
            .ForMember(dest => dest.Recipient,
                opt => opt.MapFrom(src => $"{src.Info.Delivery.FirstName} {src.Info.Delivery.LastName}"))
            .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.Info.Payment.PaymentType.ToString()))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src =>
                $"{src.Info.Delivery.Address.Country}, {src.Info.Delivery.Address.State}, {src.Info.Delivery.Address.City}, {src.Info.Delivery.Address.Street}, {src.Info.Delivery.Address.HouseNumber}"));

        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<OrderItemImageUrlResolver>())
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name));
    }
}