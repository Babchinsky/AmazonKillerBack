using FluentValidation;

namespace AmazonKiller.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(40);
        RuleFor(x => x.Description).MaximumLength(300);
        RuleFor(x => x.Status).IsInEnum();

        When(x => x.ParentId == null, () =>
        {
            RuleFor(x => x.IconName).NotEmpty().WithMessage("Icon is required for main categories");
            RuleFor(x => x.PropertyKeys).Empty().WithMessage("Main categories should not have property keys");
        });

        When(x => x.ParentId != null,
            () => { RuleFor(x => x.PropertyKeys).NotNull().WithMessage("Subcategories must have property keys"); });
    }
}