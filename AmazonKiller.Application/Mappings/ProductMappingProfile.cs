using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Features.Products.Commands.CreateProduct;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;

namespace AmazonKiller.Application.Mappings;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        // 1. Команда → Домен
        CreateMap<CreateProductCommand, Product>()
            .ForMember(dest => dest.ProductPics, opt => opt.Ignore())
            .ForMember(dest => dest.Attributes, opt => opt.Ignore())
            .ForMember(dest => dest.Features, opt => opt.Ignore())
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.RowVersion, o => o.Ignore());

        // 2. Домен → DTO
        CreateMap<Product, ProductDto>()
            .ForMember(d => d.ProductPics, o => o.MapFrom(s => s.ProductPics))
            .ForMember(d => d.RowVersion, o => o.MapFrom(s => Convert.ToBase64String(s.RowVersion)))
            .ForMember(d => d.Attributes, o => o.MapFrom(s => s.Attributes))
            .ForMember(d => d.Features, o => o.MapFrom(s => s.Features));

        // 3. Вспомогательные маппинги
        CreateMap<ProductAttribute, ProductAttributeDto>();
        CreateMap<ProductFeature, ProductFeatureDto>();
    }
}