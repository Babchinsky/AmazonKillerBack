using AmazonKiller.Application.Validators.Common;
using FluentValidation;

namespace AmazonKiller.Application.Features.Auth.Commands.Register;

public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email).ValidEmail();
        RuleFor(x => x.Password).SecurePassword();
        RuleFor(x => x.FirstName).FirstName();
        RuleFor(x => x.LastName).LastName();
    }
}