using AmazonKiller.Application.DTOs.Auth;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Registration.ConfirmRegistration;

public record ConfirmRegistrationCommand(
    string Email,
    string Code,
    string DeviceId,
    string FirstName,
    string LastName
) : IRequest<AuthTokensDto>;