using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.StartRegistration;

public record StartRegistrationCommand(string Email, string Password) : IRequest<Unit>;