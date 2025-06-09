using AmazonKiller.Application.DTOs.Auth;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.ResetPassword.CompleteResetPassword;

public record CompleteResetPasswordCommand(
    string Email,
    string Code,
    string NewPassword,
    string DeviceId
) : IRequest<AuthTokensDto>;