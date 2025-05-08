using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Domain.Entities.Reviews;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Reviews;

public class ReviewRepository(AmazonDbContext db) : IReviewRepository
{
    private IQueryable<Review> QueryWithContent()
    {
        return db.Reviews.Include(r => r.Content);
    }

    public async Task<List<ReviewDto>> GetUserReviewsAsync(Guid userId, CancellationToken ct)
    {
        var reviews = await db.Reviews
            .Where(r => r.UserId == userId)
            .Include(r => r.Content)
            .Include(r => r.Product)
            .Include(r => r.User)
            .AsNoTracking()
            .ToListAsync(ct);

        return reviews.Select(r => new ReviewDto
        {
            Id = r.Id,
            Rating = (int)r.Rating,
            Content = new ReviewContentDto(
                r.Content.Article,
                r.Content.Message,
                r.Content.FilePaths),
            ProductId = r.ProductId,
            UserId = r.UserId,
            CreatedAt = r.CreatedAt,
            UserFullName = r.User.FirstName + " " + r.User.LastName,
            ProductName = r.Product.Name,
            Tags = ["High quality", "Actual price"],
            Likes = r.Likes
        }).ToList();
    }

    public Task<List<Review>> GetAllAsync()
    {
        return QueryWithContent()
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<Review?> GetByIdAsync(Guid id)
    {
        return QueryWithContent()
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task AddAsync(Review review)
    {
        db.Reviews.Add(review);
        await db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Review review)
    {
        try
        {
            db.Reviews.Update(review);
            await db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new AppException("The review was modified by another user", 409);
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var review = await db.Reviews.FindAsync(id);
        if (review is null) return;

        db.Reviews.Remove(review);
        await db.SaveChangesAsync();
    }

    public Task<bool> IsExistsAsync(Guid id)
    {
        return db.Reviews.AnyAsync(r => r.Id == id);
    }

    public IQueryable<Review> Queryable()
    {
        return QueryWithContent();
    }

    public Task<List<Review>> GetByProductIdAsync(Guid productId)
    {
        return QueryWithContent()
            .Where(r => r.ProductId == productId)
            .OrderByDescending(r => r.CreatedAt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<double> GetAverageRatingAsync(Guid productId)
    {
        return await db.Reviews
            .Where(r => r.ProductId == productId)
            .Select(r => (int)r.Rating)
            .DefaultIfEmpty(0)
            .AverageAsync();
    }

    public Task<int> GetReviewCountAsync(Guid productId)
    {
        return db.Reviews.CountAsync(r => r.ProductId == productId);
    }

    public async Task LikeAsync(Guid reviewId, CancellationToken ct)
    {
        var review = await db.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId, ct)
                     ?? throw new NotFoundException("Review not found");

        review.Likes++;
        await db.SaveChangesAsync(ct);
    }
}