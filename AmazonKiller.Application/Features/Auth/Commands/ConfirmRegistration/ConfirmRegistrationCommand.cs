using MediatR;
using AmazonKiller.Application.DTOs.Auth;

namespace AmazonKiller.Application.Features.Auth.Commands.ConfirmRegistration;

public record ConfirmRegistrationCommand(
    string Email,
    string Code,
    string DeviceId = "debug-device",
    string IpAddress = "127.0.0.1",
    string UserAgent = "Scalar"
) : IRequest<AuthTokensDto>;