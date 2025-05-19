using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Services
{
    public class PropertyKeyUpdater(
        ICategoryRepository categoryRepo,
        IProductRepository productRepo) : IPropertyKeyUpdater
    {
        public async Task UpdateCategoryPropertyKeysAsync(
            Guid categoryId,
            IEnumerable<string> usedKeys,
            CancellationToken ct)
        {
            var category = await categoryRepo.GetByIdAsync(categoryId, ct);
            if (category?.ParentId == null)
                return; // only update for subcategories

            var keysToAdd = usedKeys.Distinct().Except(category.PropertyKeys).ToList();
            var changed = false;

            if (keysToAdd.Count != 0)
            {
                foreach (var key in keysToAdd)
                    category.PropertyKeys.Add(key);

                changed = true;
            }

            // Проверим все ключи, используемые в этой категории (по товарам)
            var allKeysInCategory = await productRepo.Queryable()
                .Where(p => p.CategoryId == categoryId)
                .SelectMany(p => p.Attributes.Select(a => a.Key))
                .Distinct()
                .ToListAsync(ct);

            if (!category.PropertyKeys.OrderBy(x => x).SequenceEqual(allKeysInCategory.OrderBy(x => x)))
            {
                category.PropertyKeys = allKeysInCategory;
                changed = true;
            }

            if (changed)
                await categoryRepo.UpdateAsync(category, ct);
        }
    }
}