using AmazonKiller.Application.Validators.Common;
using FluentValidation;

namespace AmazonKiller.Application.Features.Auth.Commands.ResetPassword.StartResetPassword;

public class StartResetPasswordValidator : AbstractValidator<StartResetPasswordCommand>
{
    public StartResetPasswordValidator()
    {
        RuleFor(x => x.Email).ValidEmail();
    }
}