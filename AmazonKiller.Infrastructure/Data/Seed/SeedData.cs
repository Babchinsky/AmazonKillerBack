using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Infrastructure.Data.Seed.CategoriesSeed;
using AmazonKiller.Infrastructure.Data.Seed.ProductsSeed;
using AmazonKiller.Infrastructure.Data.Seed.Reviews;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // 1. Сидим продукты — они будут использоваться для анализа атрибутов
        ProductsFashionCategorySeed.Seed(modelBuilder);
        ProductsElectronicsCategorySeed.Seed(modelBuilder);
        ProductsHouseholdCategorySeed.Seed(modelBuilder);
        ProductsFurnitureCategorySeed.Seed(modelBuilder);
        ProductsWorkToolsCategorySeed.Seed(modelBuilder);

        // 2. Считаем атрибуты продуктов и категории
        var attributes = new List<(Guid ProductId, string Key)>();
        var products = new List<(Guid Id, Guid CategoryId)>();

        modelBuilder.Model.GetEntityTypes()
            .Where(e => e.ClrType == typeof(ProductAttribute))
            .Select(_ => modelBuilder.Entity<ProductAttribute>().Metadata)
            .ToList()
            .ForEach(entity =>
            {
                var data = entity.GetSeedData();
                attributes.AddRange(from row in data
                    let productId = Guid.Parse(row["ProductId"]!.ToString()!)
                    let key = row["Key"]?.ToString()!
                    select (productId, key));
            });

        modelBuilder.Model.GetEntityTypes()
            .Where(e => e.ClrType == typeof(Product))
            .Select(_ => modelBuilder.Entity<Product>().Metadata)
            .ToList()
            .ForEach(entity =>
            {
                var data = entity.GetSeedData();
                products.AddRange(from row in data
                    let id = Guid.Parse(row["Id"]!.ToString()!)
                    let categoryId = Guid.Parse(row["CategoryId"]!.ToString()!)
                    select (id, categoryId));
            });

        var categoryKeysMap = products
            .GroupJoin(
                attributes,
                p => p.Id,
                a => a.ProductId,
                (p, attrs) => new { p.CategoryId, Keys = attrs.Select(a => a.Key) }
            )
            .GroupBy(x => x.CategoryId)
            .ToDictionary(
                g => g.Key,
                g => g.SelectMany(x => x.Keys).Distinct().ToList()
            );

        // 3. Сидим категории с PropertyKeys
        FashionCategorySeed.Seed(modelBuilder, categoryKeysMap);
        ElectronicsCategorySeed.Seed(modelBuilder, categoryKeysMap);
        HouseholdCategorySeed.Seed(modelBuilder, categoryKeysMap);
        FurnitureCategorySeed.Seed(modelBuilder, categoryKeysMap);
        WorkToolsCategorySeed.Seed(modelBuilder, categoryKeysMap);

        // 4. Остальные сиды
        UsersSeed.Seed(modelBuilder);

        ReviewsSeed.Seed(modelBuilder);
        ReviewLikesSeed.Seed(modelBuilder);
    }
}