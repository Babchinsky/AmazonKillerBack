using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.ResetPassword.StartResetPassword;

public record StartResetPasswordCommand(string Email) : IRequest;