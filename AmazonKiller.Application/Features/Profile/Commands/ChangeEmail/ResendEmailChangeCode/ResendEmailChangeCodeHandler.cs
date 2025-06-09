using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Profile.Commands.ChangeEmail.ResendEmailChangeCode;

public class ResendEmailChangeCodeHandler(
    IEmailVerificationRepository emailVerificationRepo,
    IVerificationEmailSender emailSender,
    ICurrentUserService currentUserService,
    IAccountRepository accountRepo
) : IRequestHandler<ResendEmailChangeCodeCommand>
{
    public async Task Handle(ResendEmailChangeCodeCommand request, CancellationToken ct)
    {
        var userId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(userId, ct);

        var entry = await emailVerificationRepo
            .GetLatestEntryByUserIdAsync(userId, VerificationType.EmailChange, ct);

        if (entry is null || entry.ExpiresAt < DateTime.UtcNow)
            throw new AppException("No pending email change request");

        await emailSender.CreateAndSendAsync(
            entry.Email,
            "Confirm your new email",
            VerificationType.EmailChange,
            tempHash: entry.TempPasswordHash,
            userId: userId,
            ct);
    }
}