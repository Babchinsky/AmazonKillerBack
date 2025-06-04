using AmazonKiller.Application.DTOs.Auth;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Registration.CompleteRegistration;

public record CompleteRegistrationCommand(
    string Email,
    string Code,
    string FirstName,
    string LastName,
    string DeviceId
) : IRequest<AuthTokensDto>;