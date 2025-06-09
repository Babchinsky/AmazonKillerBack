using AmazonKiller.Application.Validators.Common;
using FluentValidation;

namespace AmazonKiller.Application.Features.Auth.Commands.ResendVerificationCode;

public class ResendVerificationCodeValidator : AbstractValidator<ResendVerificationCodeCommand>
{
    public ResendVerificationCodeValidator()
    {
        RuleFor(x => x.Email).ValidEmail();
    }
}