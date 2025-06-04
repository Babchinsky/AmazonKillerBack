using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Categories.Public.Queries.GetCategoryFilters;

public class GetCategoryFiltersHandler(
    IProductRepository repo,
    ICategoryQueryService categoryQueryService
) : IRequestHandler<GetCategoryFiltersQuery, CategoryFiltersDto>
{
    public async Task<CategoryFiltersDto> Handle(GetCategoryFiltersQuery q, CancellationToken ct)
    {
        var category = await categoryQueryService.GetByIdIfVisibleAsync(q.CategoryId, false, ct);

        if (category is null)
            throw new NotFoundException("Category not found");

        var keys = category.PropertyKeys;
        var descendantIds = await categoryQueryService.GetDescendantCategoryIdsAsync(q.CategoryId, ct);
        descendantIds.Add(q.CategoryId);

        var products = await repo.Queryable()
            .Where(p => descendantIds.Contains(p.CategoryId))
            .Select(p => p.Attributes)
            .ToListAsync(ct);


        var result = new Dictionary<string, List<string>>();

        foreach (var key in keys)
        {
            var values = products
                .SelectMany(attrList => attrList)
                .Where(a => a.Key == key)
                .Select(a => a.Value)
                .Distinct()
                .ToList();

            if (values.Count > 0)
                result[key] = values;
        }

        return new CategoryFiltersDto { Filters = result };
    }
}