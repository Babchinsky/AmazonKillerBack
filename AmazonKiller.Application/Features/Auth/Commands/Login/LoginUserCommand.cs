using AmazonKiller.Application.DTOs.Auth;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Login;

public record LoginUserCommand(
    string Email,
    string Password,
    string DeviceId = "debug-device",
    string IpAddress = "127.0.0.1",
    string UserAgent = "Scalar"
) : IRequest<AuthTokensDto>;