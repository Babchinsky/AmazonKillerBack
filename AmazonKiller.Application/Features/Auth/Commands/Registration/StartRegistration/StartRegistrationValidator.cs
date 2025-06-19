using AmazonKiller.Application.Validators.Common;
using FluentValidation;

namespace AmazonKiller.Application.Features.Auth.Commands.Registration.StartRegistration;

public class StartRegistrationValidator : AbstractValidator<StartRegistrationCommand>
{
    public StartRegistrationValidator()
    {
        RuleFor(x => x.Email).ValidEmail();
        RuleFor(x => x.Password).SecurePassword();
    }
}