using FluentValidation;

namespace AmazonKiller.Application.Validators.Common;

public static class NameRules
{
    public static IRuleBuilderOptions<T, string> FirstName<T>(this IRuleBuilder<T, string> rule) =>
        rule.NotEmpty().Length(2, 20).WithMessage("First name must be between 2 and 20 characters");

    public static IRuleBuilderOptions<T, string> LastName<T>(this IRuleBuilder<T, string> rule) =>
        rule.NotEmpty().Length(2, 20).WithMessage("Last name must be between 2 and 20 characters");
}