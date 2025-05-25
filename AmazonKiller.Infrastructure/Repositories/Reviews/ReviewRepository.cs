using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Domain.Entities.Reviews;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Reviews;

public class ReviewRepository(AmazonDbContext db, IMapper mapper) : IReviewRepository
{
    public IQueryable<Review> Queryable()
    {
        return db.Reviews;
    }

    public async Task<ReviewDto?> GetDtoByIdAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await db.Reviews
            .Include(r => r.Product)
            .Include(r => r.User)
            .Include(r => r.LikesFromUsers)
            .FirstOrDefaultAsync(x => x.Id == id, ct);

        return entity is null ? null : mapper.Map<ReviewDto>(entity);
    }

    public IQueryable<Review> GetAllWithIncludes()
    {
        return db.Reviews
            .Include(r => r.Product)
            .Include(r => r.User)
            .Include(r => r.LikesFromUsers);
    }

    public Task<Review?> GetEntityByIdAsync(Guid id, CancellationToken ct = default)
    {
        return db.Reviews.FirstOrDefaultAsync(r => r.Id == id, ct);
    }

    public async Task AddAsync(Review review, CancellationToken ct = default)
    {
        try
        {
            db.Reviews.Add(review);
            await db.SaveChangesAsync(ct);
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("FK_Reviews_Products_ProductId") == true)
        {
            throw new AppException("Invalid ProductId: the specified product does not exist.");
        }
    }

    public async Task UpdateAsync(Review review, CancellationToken ct = default)
    {
        db.Entry(review).Property(nameof(Review.RowVersion)).OriginalValue = review.RowVersion;
        db.Reviews.Update(review);
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Review review, CancellationToken ct = default)
    {
        db.Reviews.Remove(review);
        await db.SaveChangesAsync(ct);
    }

    public async Task ToggleLikeAsync(Guid reviewId, Guid userId, CancellationToken ct)
    {
        var existing = await db.Set<ReviewLike>()
            .FirstOrDefaultAsync(x => x.ReviewId == reviewId && x.UserId == userId, ct);

        if (existing is null)
            db.Set<ReviewLike>().Add(new ReviewLike { ReviewId = reviewId, UserId = userId });
        else
            db.Set<ReviewLike>().Remove(existing);

        await db.SaveChangesAsync(ct);
    }
}