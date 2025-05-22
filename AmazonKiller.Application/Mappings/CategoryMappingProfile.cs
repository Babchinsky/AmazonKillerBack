using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Mappings.ImageUrlResolvers;
using AmazonKiller.Domain.Entities.Categories;
using AutoMapper;

namespace AmazonKiller.Application.Mappings;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        // Маппинг для дерева
        CreateMap<Category, CategoryTreeDto>()
            .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()))
            .ForMember(d => d.Children, o => o.MapFrom(s => s.Children));

        // Category → CategoryDto
        CreateMap<Category, CategoryDto>()
            .ForMember(d => d.RowVersion,
                o => o.MapFrom(s => Convert.ToBase64String(s.RowVersion)))
            .ForMember(d => d.ImageUrl,
                o => o.MapFrom<CategoryImageUrlResolver>());

        CreateMap<Category, CategoryDetailsDto>()
            .IncludeBase<Category, CategoryDto>() // использовать базовое сопоставление
            .ForMember(d => d.Filters, o => o.Ignore()); // фильтры задаются вручную
    }
}