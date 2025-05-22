using AmazonKiller.Domain.Entities.Common;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Domain.Entities.Reviews;

public class Review : VersionedEntity
{
    public Guid ProductId { get; init; }
    public Product Product { get; init; } = null!;

    public Guid UserId { get; init; }
    public User User { get; init; } = null!;

    public string Article { get; set; } = null!;
    public string Message { get; set; } = null!;
    public List<string> FilePaths { get; set; } = [];
    public List<string> Tags { get; set; } = [];

    public decimal Rating { get; set; }
    public DateTime CreatedAt { get; init; }
    public ICollection<ReviewLike> LikesFromUsers { get; init; } = new List<ReviewLike>();
}