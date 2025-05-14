using AmazonKiller.Application.DTOs.Auth;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Login;

public record LoginUserCommand(
    string Email,
    string Password,
    string DeviceId
) : IRequest<AuthTokensDto>;