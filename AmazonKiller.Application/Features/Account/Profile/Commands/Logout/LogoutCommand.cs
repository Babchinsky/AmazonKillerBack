using MediatR;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.Logout;

public record LogoutCommand : IRequest<Unit>;