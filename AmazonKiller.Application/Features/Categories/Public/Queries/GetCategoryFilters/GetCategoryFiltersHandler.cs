using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Interfaces.Services.Categories;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Public.Queries.GetCategoryFilters;

public class GetCategoryFiltersHandler(
    ICategoryQueryService categoryQueryService,
    ICategoryFilterBuilder filterBuilder
) : IRequestHandler<GetCategoryFiltersQuery, CategoryFiltersDto>
{
    public async Task<CategoryFiltersDto> Handle(GetCategoryFiltersQuery q, CancellationToken ct)
    {
        var category = await categoryQueryService.GetByIdIfVisibleAsync(q.CategoryId, ct)
                       ?? throw new NotFoundException("Category not found");

        var descendantIds = await categoryQueryService.GetDescendantCategoryIdsAsync(q.CategoryId, ct);
        descendantIds.Add(q.CategoryId);

        var result = await filterBuilder.BuildFiltersAsync(descendantIds, ct, category.ActivePropertyKeys);
        return new CategoryFiltersDto { Filters = result };
    }
}