using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Features.Products.Commands.CreateProduct;
using AmazonKiller.Application.Features.Products.Commands.UpdateProduct;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;

namespace AmazonKiller.Application.Mappings;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<CreateProductCommand, Product>()
            .ForMember(d => d.Details, o => o.Ignore()); // остальное по-умолчанию

        CreateMap<UpdateProductCommand, Product>()
            .ForMember(d => d.Details, o => o.Ignore())
            .ForMember(d => d.RowVersion, o => o.Ignore()); // RowVersion управляется БД

        CreateMap<Product, ProductDto>();
    }
}