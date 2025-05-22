using AmazonKiller.Application.Interfaces.Auth;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.ChangePassword;

public class ChangePasswordHandler(
    ICurrentUserService currentUser,
    IPasswordService passwordService,
    IAccountRepository repo)
    : IRequestHandler<ChangePasswordCommand, Unit>
{
    public async Task<Unit> Handle(ChangePasswordCommand cmd, CancellationToken ct)
    {
        // Получаем пользователя
        var user = await repo.GetCurrentUserAsync(currentUser.UserId, ct);
        if (user is null)
            throw new NotFoundException("User not found");

        // Проверка текущего пароля
        if (!passwordService.VerifyPassword(cmd.CurrentPassword, user.PasswordHash))
            throw new AppException("Current password is incorrect", 403);

        // Проверка нового пароля
        if (passwordService.VerifyPassword(cmd.NewPassword, user.PasswordHash))
            throw new AppException("New password cannot be the same as the current password");

        // Обновляем пароль
        user.PasswordHash = passwordService.HashPassword(cmd.NewPassword);
        await repo.SaveChangesAsync(ct);

        return Unit.Value;
    }
}