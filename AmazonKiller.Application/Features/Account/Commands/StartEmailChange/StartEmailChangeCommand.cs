using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.StartEmailChange;

public record StartEmailChangeCommand(string NewEmail) : IRequest;