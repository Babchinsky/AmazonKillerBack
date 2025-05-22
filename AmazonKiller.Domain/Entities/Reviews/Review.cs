using System.ComponentModel.DataAnnotations;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Domain.Entities.Reviews;

public class Review
{
    public Guid Id { get; init; }
    public Guid ContentId { get; init; }
    public ReviewContent Content { get; init; } = null!;
    public decimal Rating { get; set; }

    public Guid ProductId { get; init; }
    public Product Product { get; init; } = null!;

    public Guid UserId { get; init; }
    public User User { get; init; } = null!;

    public DateTime CreatedAt { get; init; }
    public int Likes { get; set; }

    [Timestamp] public byte[] RowVersion { get; init; } = [];
}