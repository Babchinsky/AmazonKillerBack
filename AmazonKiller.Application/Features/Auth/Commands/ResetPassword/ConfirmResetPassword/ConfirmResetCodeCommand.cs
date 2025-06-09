using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.ResetPassword.ConfirmResetPassword;

public record ConfirmResetCodeCommand(string Email, string Code) : IRequest;