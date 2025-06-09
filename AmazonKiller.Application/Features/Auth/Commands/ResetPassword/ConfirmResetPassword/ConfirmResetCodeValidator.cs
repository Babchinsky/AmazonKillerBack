using AmazonKiller.Application.Validators.Common;
using FluentValidation;

namespace AmazonKiller.Application.Features.Auth.Commands.ResetPassword.ConfirmResetPassword;

public class ConfirmResetCodeValidator : AbstractValidator<ConfirmResetCodeCommand>
{
    public ConfirmResetCodeValidator()
    {
        RuleFor(x => x.Email).ValidEmail();
        RuleFor(x => x.Code).Length(6);
    }
}