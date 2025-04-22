using AmazonKiller.Application.DTOs.Auth;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Register;

public record RegisterUserCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName
) : IRequest<AuthTokensDto>;