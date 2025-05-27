using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Features.Wishlist.Queries.GetWishlist;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Account;

public class WishlistRepository(AmazonDbContext db, IMapper mapper) : IWishlistRepository
{
    private IQueryable<Wishlist> QueryWithProduct()
    {
        return db.WishlistItems
            .Include(x => x.Product);
    }

    public async Task<PagedList<ProductCardDto>> GetWishlistAsync(
        Guid userId, string? searchTerm, QueryParameters parameters, CancellationToken ct)
    {
        var query = QueryWithProduct()
            .Where(x => x.UserId == userId)
            .Select(x => x.Product)
            .AsQueryable()
            .ApplyWishlistFilters(searchTerm)
            .ApplyWishlistSorting(parameters);

        return await query.ToPagedListAsync<Product, ProductCardDto>(parameters, mapper, ct);
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