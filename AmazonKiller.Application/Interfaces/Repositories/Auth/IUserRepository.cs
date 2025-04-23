using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces.Repositories.Auth;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken ct);
    Task AddAdminAsync(User user, CancellationToken ct);
    Task<bool> IsEmailTakenAsync(string email, CancellationToken ct);
    Task ChangeEmailAsync(Guid userId, string newEmail, CancellationToken ct);
}