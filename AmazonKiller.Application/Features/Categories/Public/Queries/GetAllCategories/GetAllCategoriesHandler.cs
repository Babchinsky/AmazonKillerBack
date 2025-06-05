using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Interfaces.Services.Categories;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Public.Queries.GetAllCategories;

public class GetAllCategoriesHandler(
    ICategoryQueryService categoryQueryService,
    IMapper mapper)
    : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery _, CancellationToken ct)
    {
        var categories = await categoryQueryService.GetAllVisibleCategoriesAsync(ct);

        return mapper.Map<List<CategoryDto>>(categories);
    }
}