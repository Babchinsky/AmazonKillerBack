using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.DeleteAccount;

public record DeleteAccountCommand() : IRequest<Unit>;