using AmazonKiller.Application.Interfaces.Repositories.Auth;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Registration.ConfirmRegistration;

public class ConfirmRegistrationHandler(
    IEmailVerificationRepository repo
) : IRequestHandler<ConfirmRegistrationCommand>
{
    public async Task Handle(ConfirmRegistrationCommand cmd, CancellationToken ct)
    {
        await repo.MarkAsConfirmedAsync(cmd.Email, cmd.Code, ct);
    }
}