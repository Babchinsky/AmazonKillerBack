using AmazonKiller.Application.Validators.Common;
using FluentValidation;

namespace AmazonKiller.Application.Features.Account.Commands.StartEmailChange;

public class StartEmailChangeValidator : AbstractValidator<StartEmailChangeCommand>
{
    public StartEmailChangeValidator()
    {
        RuleFor(x => x.NewEmail).ValidEmail();
    }
}