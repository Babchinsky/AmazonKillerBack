using AmazonKiller.Application.Validators.Common;
using FluentValidation;

namespace AmazonKiller.Application.Features.Account.Commands.ChangeEmail;

public class ChangeEmailValidator : AbstractValidator<ChangeEmailCommand>
{
    public ChangeEmailValidator()
    {
        RuleFor(x => x.Email).ValidEmail();
    }
}