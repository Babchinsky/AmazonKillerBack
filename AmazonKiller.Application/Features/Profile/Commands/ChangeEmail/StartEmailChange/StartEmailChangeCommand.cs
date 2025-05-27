using MediatR;

namespace AmazonKiller.Application.Features.Profile.Commands.ChangeEmail.StartEmailChange;

public record StartEmailChangeCommand(string NewEmail) : IRequest;