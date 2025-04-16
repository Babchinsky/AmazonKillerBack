using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Refresh;

public record RefreshTokenCommand(string RefreshToken) : IRequest<string>;