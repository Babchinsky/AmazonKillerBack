using AmazonKiller.Application.Interfaces.Repositories.Collections;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Collections;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Collections;

public class CollectionRepository(AmazonDbContext db, IFileStorage fileStorage) : ICollectionRepository
{
    public IQueryable<Collection> Queryable()
    {
        return db.Collections.AsQueryable();
    }

    public Task<Collection?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return db.Collections.Include(c => c.Filters)
            .FirstOrDefaultAsync(c => c.Id == id, ct);
    }

    public async Task AddAsync(Collection c, CancellationToken ct)
    {
        db.Collections.Add(c);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Collection c, CancellationToken ct)
    {
        try
        {
            db.Collections.Update(c);
            await db.SaveChangesAsync(ct);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new AppException("Collection was modified concurrently. Please refresh the page.");
        }
    }

    public async Task DeleteAsync(Collection collection, CancellationToken ct)
    {
        var imageUrls = !string.IsNullOrWhiteSpace(collection.ImageUrl)
            ? new List<string> { collection.ImageUrl }
            : new List<string>();

        db.Collections.Remove(collection);
        await db.SaveChangesAsync(ct);

        if (imageUrls.Count > 0)
            await fileStorage.DeleteBatchSafeAsync(imageUrls, ct);
    }
}