using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Register;

public record RegisterAdminCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName,
    string Secret) : IRequest<string>; 