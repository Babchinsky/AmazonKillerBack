﻿using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces.Repositories.Auth;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken ct);
    Task<bool> IsEmailTakenAsync(string email, CancellationToken ct);
    Task ChangeEmailAsync(Guid userId, string newEmail, CancellationToken ct);
    Task<User?> GetUserByEmailAsync(string email, CancellationToken ct);
    Task RemoveRefreshTokensForDeviceAsync(Guid userId, string deviceId, CancellationToken ct);
    Task SaveAsync(CancellationToken ct);
}