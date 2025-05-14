using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.ChangePassword;

public class ChangePasswordHandler(ICurrentUserService currentUser, IAccountRepository repo)
    : IRequestHandler<ChangePasswordCommand, Unit>
{
    public async Task<Unit> Handle(ChangePasswordCommand cmd, CancellationToken ct)
    {
        // Получаем пользователя
        var user = await repo.GetCurrentUserAsync(currentUser.UserId!.Value, ct);
        if (user is null)
            throw new AppException("User not found", 404);

        // Проверка текущего пароля
        if (!BCrypt.Net.BCrypt.Verify(cmd.CurrentPassword, user.PasswordHash))
            throw new AppException("Current password is incorrect", 403);

        // Проверка нового пароля
        if (BCrypt.Net.BCrypt.Verify(cmd.NewPassword, user.PasswordHash))
            throw new AppException("New password cannot be the same as the current password");

        // Обновляем пароль
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(cmd.NewPassword);
        await repo.SaveChangesAsync(ct);

        return Unit.Value;
    }
}