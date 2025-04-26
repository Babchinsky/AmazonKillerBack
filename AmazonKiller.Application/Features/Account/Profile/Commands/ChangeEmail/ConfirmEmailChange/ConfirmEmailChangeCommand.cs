using MediatR;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.ChangeEmail.ConfirmEmailChange;

public record ConfirmEmailChangeCommand(string Code) : IRequest<Unit>;