using AmazonKiller.Application.Validators.Common;
using FluentValidation;

namespace AmazonKiller.Application.Features.Auth.Commands.ResetPassword.CompleteResetPassword;

public class CompleteResetPasswordValidator : AbstractValidator<CompleteResetPasswordCommand>
{
    public CompleteResetPasswordValidator()
    {
        RuleFor(x => x.Email).ValidEmail();
        RuleFor(x => x.Code).Length(6);
        RuleFor(x => x.NewPassword).SecurePassword();
    }
}