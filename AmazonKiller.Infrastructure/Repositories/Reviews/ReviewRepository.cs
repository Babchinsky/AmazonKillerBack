using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Domain.Entities.Reviews;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Reviews;

public class ReviewRepository(AmazonDbContext db) : IReviewRepository
{
    public async Task<List<ReviewDto>> GetUserReviewsAsync(Guid userId, CancellationToken ct)
    {
        return await db.Reviews
            .Where(r => r.UserId == userId)
            .Include(r => r.Content)
            .Include(r => r.Product)
            .Select(r => new ReviewDto
            {
                Id = r.Id,
                Rating = (int)r.Rating,
                Message = r.Content.Message,
                Article = r.Content.Article,
                FilePaths = r.Content.FilePaths,
                CreatedAt = r.CreatedAt,
                ProductName = r.Product.Name,
                UserFullName = r.User.FirstName + " " + r.User.LastName,
                Tags = new List<string> { "High quality", "Actual price" } // пока заглушка
            })
            .ToListAsync(ct);
    }
    
    public Task<List<Review>> GetAllAsync()
    {
        return db.Reviews
            .Include(r => r.Content)
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<Review?> GetByIdAsync(Guid id)
    {
        return db.Reviews
            .Include(r => r.Content)
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
        return db.Reviews.Include(r => r.Content);
    }

    public Task<List<Review>> GetByProductIdAsync(Guid productId)
    {
        return db.Reviews
            .Include(r => r.Content)
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
}