using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Interfaces.Services.Categories;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Public.Queries.GetRootCategories;

public class GetRootCategoriesHandler(
    ICategoryQueryService queryService,
    IMapper mapper
) : IRequestHandler<GetRootCategoriesQuery, List<CategoryDto>>
{
    public async Task<List<CategoryDto>> Handle(GetRootCategoriesQuery request, CancellationToken ct)
    {
        var visible = await queryService.GetAllVisibleCategoriesAsync(ct);
        var roots = visible.Where(c => c.ParentId == null).ToList();
        return mapper.Map<List<CategoryDto>>(roots);
    }
}