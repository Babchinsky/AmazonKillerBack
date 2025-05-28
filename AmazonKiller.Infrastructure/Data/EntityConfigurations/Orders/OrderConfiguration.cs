using AmazonKiller.Infrastructure.Common.EF;
using AmazonKiller.Infrastructure.Common.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.EntityConfigurations.Orders;

public class OrderConfiguration : IEntityTypeConfiguration<Domain.Entities.Orders.Order>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Orders.Order> b)
    {
        b.Property(o => o.TotalPrice)
            .UseMoneyPrecision();

        b.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        b.ConfigureRowVersion();

        b.OwnsOne(o => o.Info, info =>
        {
            info.OwnsOne(i => i.Delivery, delivery =>
            {
                delivery.Property(d => d.FirstName)
                    .IsRequired()
                    .HasMaxLength(ValidationConstants.NameMaxLength);

                delivery.Property(d => d.LastName)
                    .IsRequired()
                    .HasMaxLength(ValidationConstants.NameMaxLength);

                delivery.Property(d => d.Email)
                    .IsRequired()
                    .HasMaxLength(ValidationConstants.EmailMaxLength);

                delivery.OwnsOne(d => d.Address, a =>
                {
                    a.Property(p => p.Country)
                        .IsRequired()
                        .HasMaxLength(ValidationConstants.NameMaxLength);

                    a.Property(p => p.City)
                        .IsRequired()
                        .HasMaxLength(ValidationConstants.NameMaxLength);

                    a.Property(p => p.State)
                        .HasMaxLength(ValidationConstants.NameMaxLength);

                    a.Property(p => p.Street)
                        .IsRequired()
                        .HasMaxLength(ValidationConstants.NameMaxLength);

                    a.Property(p => p.HouseNumber)
                        .IsRequired()
                        .HasMaxLength(ValidationConstants.HouseNumberMaxLength);

                    a.Property(p => p.ApartmentNumber)
                        .HasMaxLength(ValidationConstants.HouseNumberMaxLength);

                    a.Property(p => p.PostCode)
                        .IsRequired()
                        .HasMaxLength(ValidationConstants.HouseNumberMaxLength);
                });
            });

            info.OwnsOne(i => i.Payment);
        });
    }
}