using AmazonKiller.Application.DTOs.Auth;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.ConfirmRegistration;

public record ConfirmRegistrationCommand(
    string Email,
    string Code,
    string Password,
    string FirstName,
    string LastName) : IRequest<AuthTokensDto>;