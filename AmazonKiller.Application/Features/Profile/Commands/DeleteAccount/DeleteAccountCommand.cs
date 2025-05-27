using MediatR;

namespace AmazonKiller.Application.Features.Profile.Commands.DeleteAccount;

public record DeleteAccountCommand : IRequest<Unit>;