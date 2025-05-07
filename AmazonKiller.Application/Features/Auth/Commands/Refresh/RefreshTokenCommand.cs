using AmazonKiller.Application.DTOs.Auth;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Refresh;

public record RefreshTokenCommand(
    string RefreshToken,
    string DeviceId = "debug-device",
    string IpAddress = "127.0.0.1",
    string UserAgent = "Scalar"
) : IRequest<AuthTokensDto>;