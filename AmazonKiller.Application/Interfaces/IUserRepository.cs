using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken ct);
    Task<bool> IsEmailTakenAsync(string email, CancellationToken ct);
}