using AmazonKiller.Application.DTOs.Account;
using AmazonKiller.Application.DTOs.Account.Wishlist;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Account;

public class WishlistRepository(AmazonDbContext db, IMapper mapper) : IWishlistRepository
{
    private IQueryable<Wishlist> QueryWithProductAndSale()
    {
        return db.WishlistItems
            .Include(x => x.Product)
            .ThenInclude(p => p.Sale);
    }

    public async Task<List<ProductInWishlistDto>> GetWishlistAsync(Guid userId, CancellationToken ct)
    {
        var wishlist = await QueryWithProductAndSale()
            .Where(x => x.UserId == userId)
            .ToListAsync(ct);

        return mapper.Map<List<ProductInWishlistDto>>(wishlist);
    }

    public async Task ToggleAsync(Guid userId, Guid productId, CancellationToken ct)
    {
        var item = await db.WishlistItems
            .FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId, ct);

        if (item != null)
            db.WishlistItems.Remove(item);
        else
            db.WishlistItems.Add(new Wishlist
            {
                UserId = userId,
                ProductId = productId,
                AddedAt = DateTime.UtcNow
            });

        await db.SaveChangesAsync(ct);
    }

    public async Task AddAsync(Guid userId, Guid productId, CancellationToken ct)
    {
        var exists = await db.WishlistItems
            .AnyAsync(x => x.UserId == userId && x.ProductId == productId, ct);

        if (!exists)
        {
            db.WishlistItems.Add(new Wishlist
            {
                UserId = userId,
                ProductId = productId,
                AddedAt = DateTime.UtcNow
            });

            await db.SaveChangesAsync(ct);
        }
    }

    public async Task DeleteAsync(Guid userId, Guid productId, CancellationToken ct)
    {
        var entity = await db.WishlistItems
            .FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId, ct);

        if (entity != null)
        {
            db.WishlistItems.Remove(entity);
            await db.SaveChangesAsync(ct);
        }
    }
}