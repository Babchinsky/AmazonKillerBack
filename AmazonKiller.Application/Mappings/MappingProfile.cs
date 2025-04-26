using AmazonKiller.Application.DTOs;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Features.Products.Commands.CreateProduct;
using AmazonKiller.Application.Features.Products.Commands.UpdateProduct;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;
using NUlid;

namespace AmazonKiller.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductCommand, Product>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(_ => Ulid.NewUlid().ToString()))
            .ForMember(dest => dest.Details, opt => opt.Ignore())
            .ForMember(dest => dest.DetailsId, opt => opt.MapFrom(src => src.DetailsId));

        CreateMap<UpdateProductCommand, Product>()
            .ForMember(dest => dest.Details, opt => opt.Ignore())
            .ForMember(dest => dest.DetailsId, opt => opt.MapFrom(src => src.DetailsId));

        CreateMap<Product, ProductDto>();
    }
}