﻿using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Infrastructure.Common.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.EntityConfigurations.Products;

public class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
{
    public void Configure(EntityTypeBuilder<ProductFeature> b)
    {
        b.HasKey(x => x.Id);
        b.Property(x => x.Name).HasMaxLength(ValidationConstants.ProductFeatureNameMaxLength).IsRequired();
        b.Property(x => x.Description).HasMaxLength(ValidationConstants.ProductFeatureDescriptionMaxLength)
            .IsRequired();
        b.HasOne(x => x.Product)
            .WithMany(p => p.Features)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}