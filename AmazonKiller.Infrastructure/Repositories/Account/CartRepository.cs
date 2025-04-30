using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Account;

public class CartRepository(AmazonDbContext db) : ICartRepository
{
    public async Task AddAsync(Guid userId, Guid productId, int quantity, CancellationToken ct)
    {
        var product = await db.Products
                          .AsNoTracking()
                          .FirstOrDefaultAsync(p => p.Id == productId, ct)
                      ?? throw new AppException("Product not found");

        var exists = await db.CartLists.AnyAsync(x => x.UserId == userId && x.ProductId == productId, ct);
        if (!exists)
        {
            db.CartLists.Add(new CartList
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ProductId = productId,
                Quantity = quantity,
                Price = (int)product.Price // или Math.Round(product.Price * quantity)
            });
            await db.SaveChangesAsync(ct);
        }
    }

    public async Task RemoveAsync(Guid userId, Guid productId, CancellationToken ct)
    {
        var item = await db.CartLists.FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId, ct);
        if (item is not null)
        {
            db.CartLists.Remove(item);
            await db.SaveChangesAsync(ct);
        }
    }

    public async Task UpdateQuantityAsync(Guid userId, Guid productId, int quantity, CancellationToken ct)
    {
        var item = await db.CartLists.FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId, ct);
        if (item is not null)
        {
            item.Quantity = quantity;
            await db.SaveChangesAsync(ct);
        }
    }

    public Task<List<CartList>> GetCartItemsWithProductsAsync(Guid userId, CancellationToken ct)
    {
        return db.CartLists
            .Include(c => c.Product)
            .Where(c => c.UserId == userId)
            .ToListAsync(ct);
    }

    public async Task ClearCartAsync(Guid userId, CancellationToken ct)
    {
        var items = await db.CartLists.Where(c => c.UserId == userId).ToListAsync(ct);
        db.CartLists.RemoveRange(items);
        await db.SaveChangesAsync(ct);
    }

    public Task<CartList?> GetAsync(Guid userId, Guid productId, CancellationToken ct)
    {
        return db.CartLists
            .FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId, ct);
    }
}