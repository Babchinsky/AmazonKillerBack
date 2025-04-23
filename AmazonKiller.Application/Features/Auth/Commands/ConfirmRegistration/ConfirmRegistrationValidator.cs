using AmazonKiller.Application.Validators.Common;
using FluentValidation;

namespace AmazonKiller.Application.Features.Auth.Commands.ConfirmRegistration;

public class ConfirmRegistrationValidator : AbstractValidator<ConfirmRegistrationCommand>
{
    public ConfirmRegistrationValidator()
    {
        RuleFor(x => x.Email).ValidEmail();
        RuleFor(x => x.Code).Length(6);
    }
}