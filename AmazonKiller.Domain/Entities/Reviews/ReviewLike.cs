using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Domain.Entities.Reviews;

public class ReviewLike
{
    public Guid ReviewId { get; init; }
    public Review Review { get; init; } = null!;

    public Guid UserId { get; init; }
    public User User { get; init; } = null!;

    public DateTime LikedAt { get; init; } = DateTime.UtcNow;
}