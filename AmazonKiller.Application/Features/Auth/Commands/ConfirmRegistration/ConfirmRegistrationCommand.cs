using MediatR;
using AmazonKiller.Application.DTOs.Auth;

namespace AmazonKiller.Application.Features.Auth.Commands.ConfirmRegistration;

public record ConfirmRegistrationCommand(
    string Email,
    string Code
) : IRequest<AuthTokensDto>;