using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Infrastructure.Data;
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
}