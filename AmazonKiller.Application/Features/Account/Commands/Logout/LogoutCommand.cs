using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.Logout;

public record LogoutCommand() : IRequest<Unit>;