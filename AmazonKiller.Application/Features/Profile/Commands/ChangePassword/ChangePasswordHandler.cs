using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Application.Interfaces.Services.Auth;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Profile.Commands.ChangePassword;

public class ChangePasswordHandler(
    ICurrentUserService currentUserService,
    IPasswordService passwordService,
    IAccountRepository accountRepo)
    : IRequestHandler<ChangePasswordCommand, Unit>
{
    public async Task<Unit> Handle(ChangePasswordCommand cmd, CancellationToken ct)
    {
        var currentUserId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(currentUserId, ct);

        // Получаем пользователя
        var user = await accountRepo.GetUserByIdAsync(currentUserId, ct);
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
        await accountRepo.SaveChangesAsync(ct);

        return Unit.Value;
    }
}