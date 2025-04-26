using AmazonKiller.Application.Validators.Common;
using FluentValidation;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.ChangeName;

public class ChangeNameValidator : AbstractValidator<ChangeNameCommand>
{
    public ChangeNameValidator()
    {
        RuleFor(x => x.FirstName).FirstName();
        RuleFor(x => x.LastName).LastName();
    }
}