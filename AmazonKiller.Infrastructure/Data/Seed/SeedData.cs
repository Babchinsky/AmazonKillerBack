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
        Electronics_LenovoLaptop.Seed(modelBuilder);
        Electronics_SonyCamera.Seed(modelBuilder);
        Electronics_SamsungTV.Seed(modelBuilder);

        Fashion_MensDenimJacket.Seed(modelBuilder);
        Fashion_ZaraFloralDress.Seed(modelBuilder);
        Fashion_WomensSneakers.Seed(modelBuilder);
        Fashion_WomensHat.Seed(modelBuilder);
        Fashion_MensLeatherJacket.Seed(modelBuilder);

        Furniture_ModernCoffeeTable.Seed(modelBuilder);
        Furniture_IkeaLackTable.Seed(modelBuilder);
        Furniture_BedsideTable.Seed(modelBuilder);
        Furniture_OfficeChair.Seed(modelBuilder);
        Furniture_WoodenBookshelf.Seed(modelBuilder);

        Household_DysonV15.Seed(modelBuilder);
        Household_ToiletBrushSet.Seed(modelBuilder);
        Household_LaundryBasket.Seed(modelBuilder);
        Household_AirPurifier.Seed(modelBuilder);
        Household_WaterPurifier.Seed(modelBuilder);

        WorkTools_DeWaltDrill.Seed(modelBuilder);
        WorkTools_MakitaDrill.Seed(modelBuilder);
        WorkTools_UtilityGloves.Seed(modelBuilder);
        WorkTools_SafetyHelmet.Seed(modelBuilder);
        WorkTools_PortableDrill.Seed(modelBuilder);

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