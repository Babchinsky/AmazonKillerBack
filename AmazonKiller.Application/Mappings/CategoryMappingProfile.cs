using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;

namespace AmazonKiller.Application.Mappings;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CategoryTreeDto>()
            .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()))
            .ForMember(d => d.Children, o => o.MapFrom(s => s.Children));

        CreateMap<Category, CategoryDto>();
    }
}