using AmazonKiller.Application.Interfaces.Repositories.Auth;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.ResetPassword.ConfirmResetPassword;

public class ConfirmResetCodeHandler(
    IEmailVerificationRepository repo
) : IRequestHandler<ConfirmResetCodeCommand>
{
    public async Task Handle(ConfirmResetCodeCommand cmd, CancellationToken ct)
    {
        await repo.MarkAsConfirmedAsync(cmd.Email, cmd.Code, ct);
    }
}