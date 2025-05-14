using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.ChangeEmail.StartEmailChange;

public class StartEmailChangeHandler(
    IVerificationEmailSender verificationEmailSender,
    IEmailVerificationRepository repo,
    ICurrentUserService currentUserService,
    IConfiguration config,
    IAccountRepository accountRepo
) : IRequestHandler<StartEmailChangeCommand>
{
    private readonly bool _useFixedCode = config.GetValue<bool>("Verification:UseFixedCode");
    private readonly string? _fixedCode = config.GetValue<string>("Verification:FixedCodeValue");

    public async Task Handle(StartEmailChangeCommand cmd, CancellationToken ct)
    {
        var userId = currentUserService.UserId ?? throw new AppException("Unauthorized", 401);

        // Получаем текущего пользователя
        var user = await accountRepo.GetCurrentUserAsync(userId, ct);
        if (user == null)
            throw new AppException("User not found", 404);

        // Если новый email совпадает с текущим, не разрешаем изменить
        if (user.Email == cmd.NewEmail)
            throw new AppException("New email cannot be the same as the current email");

        // Генерируем код
        var code = _useFixedCode ? _fixedCode : new Random().Next(100000, 999999).ToString();

        var entry = new EmailVerification
        {
            Email = cmd.NewEmail,
            Code = code,
            ExpiresAt = DateTime.UtcNow.AddMinutes(10),
            UserId = userId
        };

        await repo.AddAsync(entry, ct);

        await verificationEmailSender.SendVerificationCodeAsync(cmd.NewEmail, "Confirm your new email", code);
    }
}