using AmazonKiller.Domain.Entities.Collections;

namespace AmazonKiller.Application.Interfaces.Repositories.Collections;

public interface ICollectionRepository
{
    IQueryable<Collection> Queryable();
    Task<Collection?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Collection collection, CancellationToken ct = default);
    Task UpdateAsync(Collection collection, CancellationToken ct = default);
    Task DeleteAsync(Collection collection, CancellationToken ct = default);
}