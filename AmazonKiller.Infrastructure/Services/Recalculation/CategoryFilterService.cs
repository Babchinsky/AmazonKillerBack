using AmazonKiller.Application.Interfaces.Services.Recalculation;
using AmazonKiller.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Services.Recalculation;

public sealed class CategoryFilterService(AmazonDbContext db) : ICategoryFilterService
{
    public async Task RecalculateAsync(bool resetActive = false, CancellationToken ct = default)
    {
        // 1. Собираем (ProductId, Key)
        var attr = await db.ProductAttributes
            .Select(a => new { a.ProductId, a.Key })
            .ToListAsync(ct);

        // 2. Собираем (ProductId, CategoryId)
        var map = await db.Products
            .Select(p => new { p.Id, p.CategoryId })
            .ToListAsync(ct);

        // 3. Группируем по CategoryId
        var keysByCategory = map
            .GroupJoin(attr,
                p => p.Id,
                a => a.ProductId,
                (p, attrs) => new { p.CategoryId, Keys = attrs.Select(a => a.Key) })
            .GroupBy(x => x.CategoryId)
            .ToDictionary(
                g => g.Key,
                g => g.SelectMany(x => x.Keys).Distinct().ToList()
            );

        // 4. Загружаем все категории
        var categories = await db.Categories.ToListAsync(ct);

        // 5. Обновляем каждую категорию
        foreach (var c in categories)
        {
            keysByCategory.TryGetValue(c.Id, out var newKeys);
            newKeys ??= [];

            c.PropertyKeys = newKeys;

            if (resetActive)
            {
                // 🔁 Если категория родительская — собираем ключи из всех её потомков
                var descendantKeys = categories
                    .Where(child => child.ParentId == c.Id)
                    .SelectMany(child => keysByCategory.TryGetValue(child.Id, out var childKeys) ? childKeys : [])
                    .Distinct()
                    .ToList();

                c.ActivePropertyKeys = descendantKeys;
            }
            else
            {
                // 🔁 Просто чистим несуществующие
                c.ActivePropertyKeys = c.ActivePropertyKeys.Where(k => newKeys.Contains(k)).ToList();
            }
        }

        await db.SaveChangesAsync(ct);
    }
}