using AmazonKiller.Domain.Entities.Collections;
using AmazonKiller.Infrastructure.Common.EF;
using AmazonKiller.Infrastructure.Common.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.EntityConfigurations.Collections;

public class CollectionConfiguration : IEntityTypeConfiguration<Collection>
{
    public void Configure(EntityTypeBuilder<Collection> b)
    {
        // Primary key
        b.HasKey(c => c.Id);

        // Title (required, max length)
        b.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(ValidationConstants.NameMaxLength);

        // ImageUrl (optional, max length)
        b.Property(c => c.ImageUrl)
            .HasMaxLength(ValidationConstants.ProductFeatureDescriptionMaxLength);

        b.Property(c => c.MinPrice)
            .UseMoneyPrecision();

        b.Property(c => c.MaxPrice)
            .UseMoneyPrecision();

        // IsActive: default true, index
        b.Property(c => c.IsActive)
            .HasDefaultValue(true);

        b.HasIndex(c => c.IsActive);

        // Foreign key → Category
        b.HasIndex(c => c.CategoryId);

        b.HasOne(c => c.Category)
            .WithMany(c => c.Collections)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Filters: value-object as owned entity
        b.OwnsMany(c => c.Filters, fb =>
        {
            fb.WithOwner(f => f.Collection)
                .HasForeignKey("CollectionId");

            fb.Property(f => f.Key)
                .IsRequired()
                .HasMaxLength(ValidationConstants.ProductAttributeMaxLength);

            fb.Property(f => f.Value)
                .IsRequired()
                .HasMaxLength(ValidationConstants.ProductAttributeMaxLength);

            fb.HasKey("CollectionId", "Key", "Value");

            fb.ToTable("CollectionFilters");
        });

        // RowVersion
        b.ConfigureRowVersion();
    }
}