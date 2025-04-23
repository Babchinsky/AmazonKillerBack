using AmazonKiller.Application.Validators.Common;
using FluentValidation;

namespace AmazonKiller.Application.Features.Auth.Commands.RegisterAdmin;

public class RegisterAdminValidator : AbstractValidator<RegisterAdminCommand>
{
    public RegisterAdminValidator()
    {
        RuleFor(x => x.Email).ValidEmail();
        RuleFor(x => x.Password).SecurePassword();
        RuleFor(x => x.FirstName).FirstName();
        RuleFor(x => x.LastName).LastName();
        RuleFor(x => x.Secret).NotEmpty().WithMessage("Secret is required");
    }
}