using AmazonKiller.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.EntityConfigurations.Categories;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> b)
    {
        b.Property(c => c.RowVersion)
            .IsRowVersion()
            .IsConcurrencyToken();

        b.PrimitiveCollection(c => c.PropertyKeys);
    }
}