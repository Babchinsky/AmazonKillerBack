using FluentValidation;

namespace AmazonKiller.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(40);
        RuleFor(x => x.Description).MaximumLength(300);
        RuleFor(x => x.Status).IsInEnum();

        When(x => x.ParentId == null, () =>
        {
            RuleFor(x => x.IconName).NotEmpty().WithMessage("Icon is required for main categories");
            RuleFor(x => x.PropertyKeys).Empty().WithMessage("Property keys should not be set for main categories");
        });

        When(x => x.ParentId != null,
            () =>
            {
                RuleFor(x => x.PropertyKeys).NotNull().WithMessage("Property keys must be provided for subcategories");
            });
    }
}