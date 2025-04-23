using AmazonKiller.Application.Interfaces;
using AmazonKiller.Application.Interfaces.Common;
using AmazonKiller.Application.Interfaces.Repositories;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.ChangePassword;

public class ChangePasswordHandler(ICurrentUserService currentUser, IAccountRepository repo)
    : IRequestHandler<ChangePasswordCommand, Unit>
{
    public async Task<Unit> Handle(ChangePasswordCommand cmd, CancellationToken ct)
    {
        var user = await repo.GetCurrentUserAsync(currentUser.UserId!.Value, ct);
        if (user is null)
            throw new AppException("User not found", 404);

        if (!BCrypt.Net.BCrypt.Verify(cmd.CurrentPassword, user.PasswordHash))
            throw new AppException("Current password is incorrect", 403);

        if (BCrypt.Net.BCrypt.Verify(cmd.NewPassword, user.PasswordHash))
            throw new AppException("New password cannot be the same as the current password");

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(cmd.NewPassword);
        await repo.SaveChangesAsync(ct);

        return Unit.Value;
    }
}