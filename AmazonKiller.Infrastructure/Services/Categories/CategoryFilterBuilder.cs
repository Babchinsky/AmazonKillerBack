using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services.Categories;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Services.Categories;

public class CategoryFilterBuilder(IProductRepository productRepo) : ICategoryFilterBuilder
{
    public async Task<Dictionary<string, List<string>>> BuildFiltersAsync(
        IEnumerable<Guid> categoryIds,
        CancellationToken ct,
        IEnumerable<string>? allowedKeys = null)
    {
        var attributes = await productRepo.Queryable()
            .Where(p => categoryIds.Contains(p.CategoryId))
            .SelectMany(p => p.Attributes)
            .ToListAsync(ct);

        var grouped = attributes
            .GroupBy(a => a.Key)
            .Where(g => allowedKeys == null || allowedKeys.Contains(g.Key)) // 👈 фильтрация по разрешённым ключам
            .ToDictionary(
                g => g.Key,
                g => g.Select(a => a.Value).Distinct().ToList()
            );

        return grouped;
    }
}