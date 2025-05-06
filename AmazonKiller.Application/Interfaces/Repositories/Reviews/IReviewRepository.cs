using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Domain.Entities.Reviews;

namespace AmazonKiller.Application.Interfaces.Repositories.Reviews;

public interface IReviewRepository
{
    Task<List<Review>> GetAllAsync();
    Task<Review?> GetByIdAsync(Guid id);
    Task<bool> IsExistsAsync(Guid id);
    Task AddAsync(Review review);
    Task UpdateAsync(Review review);
    Task DeleteAsync(Guid id);

    IQueryable<Review> Queryable();

    Task<List<Review>> GetByProductIdAsync(Guid productId);
    Task<double> GetAverageRatingAsync(Guid productId);
    Task<int> GetReviewCountAsync(Guid productId);
    Task<List<ReviewDto>> GetUserReviewsAsync(Guid userId, CancellationToken ct);
    Task LikeAsync(Guid reviewId, CancellationToken ct);
}