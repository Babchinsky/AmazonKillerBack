using AmazonKiller.Domain.Entities.Categories;
using AmazonKiller.Infrastructure.Common.EF;
using AmazonKiller.Infrastructure.Common.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.EntityConfigurations.Categories;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> b)
    {
        b.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(ValidationConstants.NameMaxLength);

        b.ConfigureRowVersion();

        b.PrimitiveCollection(c => c.PropertyKeys);
        b.PrimitiveCollection(c => c.ActivePropertyKeys);

        b.HasOne(c => c.Parent)
            .WithMany(c => c.Children)
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}