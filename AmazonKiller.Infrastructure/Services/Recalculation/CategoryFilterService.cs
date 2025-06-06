using AmazonKiller.Application.Interfaces.Services.Recalculation;
using AmazonKiller.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Services.Recalculation;

public sealed class CategoryFilterService(AmazonDbContext db) : ICategoryFilterService
{
    public async Task RecalculateAsync(CancellationToken ct = default)
    {
        /* 1. собираем (ProductId, Key) */
        var attr = await db.ProductAttributes
            .Select(a => new { a.ProductId, a.Key })
            .ToListAsync(ct);

        /* 2. (ProductId, CategoryId)  */
        var map = await db.Products
            .Select(p => new { p.Id, p.CategoryId })
            .ToListAsync(ct);

        /* 3. группируем по CategoryId */
        var keysByCategory = map
            .GroupJoin(attr,
                p => p.Id,
                a => a.ProductId,
                (p, attrs) => new { p.CategoryId, Keys = attrs.Select(a => a.Key) })
            .GroupBy(x => x.CategoryId)
            .ToDictionary(g => g.Key,
                g => g.SelectMany(x => x.Keys).Distinct().ToList());

        /* 4. обновляем только затронутые категории */
        var categories = await db.Categories
            .Where(c => keysByCategory.Keys.Contains(c.Id))
            .ToListAsync(ct);

        foreach (var c in categories)
            c.PropertyKeys = keysByCategory[c.Id];

        await db.SaveChangesAsync(ct);
    }
}