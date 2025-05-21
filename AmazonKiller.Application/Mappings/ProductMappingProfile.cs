using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Features.Products.Commands.CreateUpdateProduct.CreateProduct;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;

namespace AmazonKiller.Application.Mappings;

public sealed class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        /* 1. Команда → Домен -------------------------------------------- */
        CreateMap<CreateProductCommand, Product>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.RowVersion, o => o.Ignore())
            .ForMember(d => d.ImageUrls, o => o.Ignore())
            .ForMember(d => d.Attributes, o => o.Ignore())
            .ForMember(d => d.Features, o => o.Ignore());

        /* 2. Домен → DTO -------------------------------------------------- */
        CreateMap<Product, ProductDto>()
            .ForMember(d => d.ImageUrls,
                o => o.MapFrom<ImageUrlResolver>())
            .ForMember(d => d.RowVersion,
                o => o.MapFrom(s => Convert.ToBase64String(s.RowVersion)))
            .ForMember(d => d.Attributes,
                o => o.MapFrom(s => s.Attributes))
            .ForMember(d => d.Features,
                o => o.MapFrom(s => s.Features));

        /* 3. Под-объекты -------------------------------------------------- */
        CreateMap<ProductAttribute, ProductAttributeDto>();
        CreateMap<ProductFeature, ProductFeatureDto>();
    }
}