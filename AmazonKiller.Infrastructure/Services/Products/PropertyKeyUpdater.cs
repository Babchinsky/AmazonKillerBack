using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Services.Products;

public class PropertyKeyUpdater(
    ICategoryRepository categoryRepo,
    IProductRepository productRepo) : IPropertyKeyUpdater
{
    public async Task UpdateCategoryPropertyKeysAsync(
        Guid categoryId,
        IEnumerable<string> usedKeysNow,
        CancellationToken ct)
    {
        var category = await categoryRepo.GetByIdAsync(categoryId, ct);
        // if (category?.ParentId == null)
        //     return; // Только подкатегории
        if (category is null)
            return;

        var currentKeys = category.PropertyKeys.ToHashSet();
        var incomingKeys = usedKeysNow.Distinct().ToHashSet();

        var toAdd = incomingKeys.Except(currentKeys).ToList();
        var usedInProducts = await productRepo.Queryable()
            .Where(p => p.CategoryId == categoryId)
            .SelectMany(p => p.Attributes.Select(a => a.Key))
            .Distinct()
            .ToListAsync(ct);

        var toRemove = category.PropertyKeys.Except(usedInProducts).ToList();

        foreach (var key in toAdd)
            category.PropertyKeys.Add(key);

        foreach (var key in toRemove)
            category.PropertyKeys.Remove(key);

        if (toAdd.Count > 0 || toRemove.Count > 0)
            await categoryRepo.UpdateAsync(category, ct);
    }
}