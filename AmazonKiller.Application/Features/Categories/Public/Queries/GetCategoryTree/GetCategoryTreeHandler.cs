using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Public.Queries.GetCategoryTree;

public class GetCategoryTreeHandler(
    ICategoryQueryService categoryQueryService,
    IMapper mapper)
    : IRequestHandler<GetCategoryTreeQuery, List<CategoryTreeDto>>
{
    public async Task<List<CategoryTreeDto>> Handle(GetCategoryTreeQuery _, CancellationToken ct)
    {
        var tree = await categoryQueryService.GetTreeVisibleAsync(ct);

        return mapper.Map<List<CategoryTreeDto>>(tree);
    }
}