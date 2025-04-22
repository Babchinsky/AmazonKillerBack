using AmazonKiller.Application.Validators.Common;
using FluentValidation;

namespace AmazonKiller.Application.Features.Account.Commands.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordValidator()
    {
        RuleFor(x => x.CurrentPassword).NotEmpty();
        RuleFor(x => x.NewPassword).SecurePassword();
    }
}