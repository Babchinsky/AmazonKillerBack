using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.ChangePassword;

public record ChangePasswordCommand(string CurrentPassword, string NewPassword) : IRequest<Unit>;