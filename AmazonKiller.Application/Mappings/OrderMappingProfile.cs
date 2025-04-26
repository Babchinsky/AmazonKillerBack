using AmazonKiller.Application.DTOs.Account;
using AmazonKiller.Application.DTOs.Account.Orders;
using AmazonKiller.Domain.Entities.Orders;
using AutoMapper;

namespace AmazonKiller.Application.Mappings;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.OrderedAt, opt => opt.MapFrom(src => src.Info.OrderedAt));
    }
}