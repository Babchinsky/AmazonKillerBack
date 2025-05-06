using FluentValidation;

namespace AmazonKiller.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    private static readonly ProfanityFilter.ProfanityFilter ProfanityFilter = new();

    public CreateCategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(1).MaximumLength(20)
            .Must(name => !ProfanityFilter.IsProfanity(name));
    }
}