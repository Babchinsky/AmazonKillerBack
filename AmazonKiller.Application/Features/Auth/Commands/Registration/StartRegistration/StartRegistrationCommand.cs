using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Registration.StartRegistration;

public record StartRegistrationCommand(
    string Email,
    string Password
) : IRequest;