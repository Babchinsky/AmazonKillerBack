using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces.Repositories.Admin.Users;

public interface IAdminUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken ct);
    IQueryable<User> Queryable();
    Task SaveChangesAsync(CancellationToken ct);
    Task MarkUsersDeletedAsync(List<Guid> ids, CancellationToken ct);
    Task RestoreUsersAsync(List<Guid> ids, CancellationToken ct);
}