using MediatR;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.ChangeEmail.StartEmailChange;

public record StartEmailChangeCommand(string NewEmail) : IRequest;