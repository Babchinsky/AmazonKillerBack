using MediatR;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.DeleteAccount;

public record DeleteAccountCommand() : IRequest<Unit>;