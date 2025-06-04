using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Registration.ConfirmRegistration;

public record ConfirmRegistrationCommand(
    string Email,
    string Code
) : IRequest;