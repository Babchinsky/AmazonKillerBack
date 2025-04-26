using MediatR;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.ChangePassword;

public record ChangePasswordCommand(string CurrentPassword, string NewPassword) : IRequest<Unit>;