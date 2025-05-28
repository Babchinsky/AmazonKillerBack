using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Common.EF;
using AmazonKiller.Infrastructure.Common.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.EntityConfigurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> b)
    {
        b.Property(u => u.Email)
            .HasMaxLength(ValidationConstants.EmailMaxLength)
            .IsRequired();

        b.Property(u => u.PasswordHash)
            .IsRequired();

        b.Property(u => u.Role)
            .IsRequired();

        b.Property(u => u.Status)
            .IsRequired();

        b.Property(u => u.FirstName)
            .HasMaxLength(ValidationConstants.FirstNameMaxLength)
            .IsRequired();

        b.Property(u => u.LastName)
            .HasMaxLength(ValidationConstants.LastNameMaxLength)
            .IsRequired();

        b.Property(u => u.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        b.ConfigureRowVersion();
    }
}