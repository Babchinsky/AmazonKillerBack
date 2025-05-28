using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Infrastructure.Common.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.EntityConfigurations.Products;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> e)
    {
        e.HasIndex(p => p.Code).IsUnique();

        e.PrimitiveCollection(p => p.ImageUrls);

        e.Property(p => p.Price).UseMoneyPrecision();
        e.Property(p => p.DiscountPercent).UseDiscountPrecision();

        e.Property(p => p.Rating).UseRatingPrecision();

        e.ConfigureRowVersion();
    }
}