using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services.Categories;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Services.Categories;

public class CategoryFilterBuilder(IProductRepository productRepo) : ICategoryFilterBuilder
{
    public async Task<Dictionary<string, List<string>>> BuildFiltersAsync(IEnumerable<Guid> categoryIds,
        CancellationToken ct)
    {
        var productAttrs = await productRepo.Queryable()
            .Where(p => categoryIds.Contains(p.CategoryId))
            .Select(p => p.Attributes)
            .ToListAsync(ct);

        var allKeys = productAttrs
            .SelectMany(attrs => attrs)
            .Select(a => a.Key)
            .Distinct();

        var filters = new Dictionary<string, List<string>>();
        foreach (var key in allKeys)
        {
            var values = productAttrs
                .SelectMany(attrs => attrs)
                .Where(a => a.Key == key)
                .Select(a => a.Value)
                .Distinct()
                .ToList();

            if (values.Count > 0)
                filters[key] = values;
        }

        return filters;
    }
}