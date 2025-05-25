using AmazonKiller.Application.DTOs.Account.Cart;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Features.Products.Commands.CreateUpdateProduct.CreateProduct;
using AmazonKiller.Application.Mappings.ImageUrlResolvers.Products;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;

namespace AmazonKiller.Application.Mappings;

public sealed class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        // 1. Команда → Домен
        CreateMap<CreateProductCommand, Product>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.RowVersion, o => o.Ignore())
            .ForMember(d => d.ImageUrls, o => o.Ignore())
            .ForMember(d => d.Attributes, o => o.Ignore())
            .ForMember(d => d.Features, o => o.Ignore());

        // 2. Домен → ProductDto
        CreateMap<Product, ProductDto>()
            .ForMember(d => d.ImageUrls, o => o.MapFrom<ProductImageUrlResolver>())
            .ForMember(d => d.RowVersion, o => o.MapFrom(s => Convert.ToBase64String(s.RowVersion)))
            .ForMember(d => d.Attributes, o => o.MapFrom(s => s.Attributes))
            .ForMember(d => d.Features, o => o.MapFrom(s => s.Features));

        // 3. Домен → ProductCardDto (для карточек)
        CreateMap<Product, ProductCardDto>()
            .ForMember(d => d.ImageUrl, o => o.MapFrom<ProductMainImageUrlResolver>());

        // 4. Домен → CartItemDto (для карточек)
        // Product → CartItemDto
        CreateMap<Product, CartItemDto>()
            .ForMember(d => d.ImageUrl, o => o.MapFrom<ProductMainImageUrlResolver>());

        // (Product, int quantity) → CartItemDto
        CreateMap<(Product product, int quantity), CartItemDto>()
            .ForMember(d => d.ProductId, o => o.MapFrom(s => s.product.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.product.Name))
            .ForMember(d => d.ImageUrl, o => o.MapFrom<ProductTupleImageUrlResolver>())
            .ForMember(d => d.Price, o => o.MapFrom(s =>
                Math.Round(s.product.Price * (1 - (s.product.DiscountPercent ?? 0) / 100), 2)))
            .ForMember(d => d.Quantity, o => o.MapFrom(s => s.quantity));

        // 5. Под-объекты
        CreateMap<ProductAttribute, ProductAttributeDto>();
        CreateMap<ProductFeature, ProductFeatureDto>();
    }
}