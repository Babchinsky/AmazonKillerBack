using MediatR;

namespace AmazonKiller.Application.Features.Profile.Commands.Logout;

public record LogoutCommand : IRequest<Unit>;