using MediatR;

namespace AmazonKiller.Application.Features.Profile.Commands.ChangeEmail.ConfirmEmailChange;

public record ConfirmEmailChangeCommand(string Code) : IRequest<Unit>;