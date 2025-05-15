using AmazonKiller.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.Configurations.Users;

public class EmailVerificationConfiguration : IEntityTypeConfiguration<EmailVerification>
{
    public void Configure(EntityTypeBuilder<EmailVerification> b)
    {
        b.HasOne<User>()
            .WithMany()
            .HasForeignKey(ev => ev.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasIndex(ev => new { ev.Email, ev.Type });
    }
}