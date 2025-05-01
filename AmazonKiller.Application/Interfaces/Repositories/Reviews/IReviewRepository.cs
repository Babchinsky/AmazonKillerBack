using AmazonKiller.Application.DTOs.Reviews;

namespace AmazonKiller.Application.Interfaces.Repositories.Reviews;

public interface IReviewRepository
{
    Task<List<ReviewDto>> GetUserReviewsAsync(Guid userId, CancellationToken ct);
}