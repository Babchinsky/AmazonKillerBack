using System.ComponentModel.DataAnnotations;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Domain.Entities.Reviews;

public class Review
{
    public Guid Id { get; set; }
    public Guid ContentId { get; set; }
    public ReviewContent Content { get; set; } = null!;
    public Rating Rating { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int Likes { get; set; }
    [Timestamp] public byte[] RowVersion { get; set; } = [];
}