using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Domain.Entities.Reviews;

namespace AmazonKiller.Application.Interfaces.Repositories.Reviews;

public interface IReviewRepository
{
    IQueryable<Review> Queryable(); // только для update/delete
    IQueryable<Review> GetAllWithIncludes();
    Task<ReviewDto?> GetDtoByIdAsync(Guid id, CancellationToken ct = default); // ProjectTo + FirstOrDefault
    Task<Review?> GetEntityByIdAsync(Guid id, CancellationToken ct = default); // используется в Delete

    Task AddAsync(Review review, CancellationToken ct = default);
    Task UpdateAsync(Review review, CancellationToken ct = default);
    Task DeleteAsync(Review review, CancellationToken ct = default);
    Task ToggleLikeAsync(Guid reviewId, Guid userId, CancellationToken ct);
}