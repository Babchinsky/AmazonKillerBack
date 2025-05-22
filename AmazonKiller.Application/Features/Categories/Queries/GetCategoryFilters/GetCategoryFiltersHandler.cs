using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Categories.Queries.GetCategoryFilters;

public class GetCategoryFiltersHandler(IProductRepository repo, ICategoryRepository categories)
    : IRequestHandler<GetCategoryFiltersQuery, CategoryFiltersDto>
{
    public async Task<CategoryFiltersDto> Handle(GetCategoryFiltersQuery q, CancellationToken ct)
    {
        var category = await categories.GetByIdAsync(q.CategoryId, ct);
        if (category is null)
            throw new NotFoundException("Category not found");

        var keys = category.PropertyKeys;
        var products = await repo.Queryable()
            .Where(p => p.CategoryId == q.CategoryId)
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

        return new CategoryFiltersDto(result);
    }
}