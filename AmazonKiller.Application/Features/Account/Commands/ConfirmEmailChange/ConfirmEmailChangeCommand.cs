using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.ConfirmEmailChange;

public record ConfirmEmailChangeCommand(string Code) : IRequest<Unit>;