using AmazonKiller.Infrastructure.Data.Seed.CartLists;
using AmazonKiller.Infrastructure.Data.Seed.Categories;
using AmazonKiller.Infrastructure.Data.Seed.Collections;
using AmazonKiller.Infrastructure.Data.Seed.Orders;
using AmazonKiller.Infrastructure.Data.Seed.Products.Electronics;
using AmazonKiller.Infrastructure.Data.Seed.Products.Fashion;
using AmazonKiller.Infrastructure.Data.Seed.Products.Furniture;
using AmazonKiller.Infrastructure.Data.Seed.Products.Household;
using AmazonKiller.Infrastructure.Data.Seed.Products.WorkTools;
using AmazonKiller.Infrastructure.Data.Seed.Reviews;
using AmazonKiller.Infrastructure.Data.Seed.Users;
using AmazonKiller.Infrastructure.Data.Seed.Wishlists;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // 1. Сидим продукты — они будут использоваться для анализа атрибутов
        Electronics_SamsungS23Ultra.Seed(modelBuilder);
        Electronics_SonyWH1000XM5.Seed(modelBuilder);
        Electronics_IPhone15ProMax.Seed(modelBuilder);
        Electronics_BoseQCUltra.Seed(modelBuilder);

        Fashion_MensDenimJacket.Seed(modelBuilder);
        Fashion_ZaraFloralDress.Seed(modelBuilder);

        Furniture_ModernCoffeeTable.Seed(modelBuilder);
        Furniture_IkeaLackTable.Seed(modelBuilder);

        Household_DysonV15.Seed(modelBuilder);

        WorkTools_DeWaltDrill.Seed(modelBuilder);
        WorkTools_MakitaDrill.Seed(modelBuilder);

        // 3. Сидим категории с PropertyKeys
        FashionCategorySeed.Seed(modelBuilder);
        ElectronicsCategorySeed.Seed(modelBuilder);
        HouseholdCategorySeed.Seed(modelBuilder);
        FurnitureCategorySeed.Seed(modelBuilder);
        WorkToolsCategorySeed.Seed(modelBuilder);

        // 4. Остальные сиды
        UsersSeed.Seed(modelBuilder);

        ReviewsSeed.Seed(modelBuilder);
        ReviewLikesSeed.Seed(modelBuilder);

        CollectionsSeed.Seed(modelBuilder);

        WishlistsSeed.Seed(modelBuilder);

        CartListSeed.Seed(modelBuilder);

        OrdersSeed.Seed(modelBuilder);
    }
}