using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Features.Products.Commands.CreateProduct;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;

namespace AmazonKiller.Application.Mappings;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        /*  ――― 1. Запись → Домен ――― */
        CreateMap<CreateProductCommand, Product>()
            // Url-ы картинок из команды кладём в коллекцию ProductPics доменной модели
            .ForMember(dest => dest.ProductPics, opt => opt.Ignore()) // вручную добавляешь URL в handler
            .ForMember(dest => dest.Attributes, opt => opt.Ignore())
            .ForMember(dest => dest.Features, opt => opt.Ignore())
            /* остальные поля просто копируются */
            .ForMember(d => d.Id, o => o.Ignore()) // задастся в обработчике
            .ForMember(d => d.RowVersion, o => o.Ignore());

        /*  ――― 2. Домен → DTO ――― */
        CreateMap<Product, ProductDto>()
            .ForMember(d => d.ProductPics, o => o.MapFrom(s => s.ProductPics));
    }
}