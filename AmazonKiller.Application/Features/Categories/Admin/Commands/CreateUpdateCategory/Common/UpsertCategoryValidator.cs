using FluentValidation;

namespace AmazonKiller.Application.Features.Categories.Admin.Commands.CreateUpdateCategory.Common;

public abstract class UpsertCategoryValidator<T> : AbstractValidator<T>
    where T : UpsertCategoryModel
{
    protected UpsertCategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(40);
        RuleFor(x => x.Description).MaximumLength(300);
        RuleFor(x => x.Status).IsInEnum();

        RuleFor(x => x.Image)
            .Must(file => file == null || new[] { ".jpg", ".jpeg", ".png", ".webp" }
                .Contains(Path.GetExtension(file.FileName).ToLower()))
            .WithMessage("Only .jpg, .jpeg, .png, .webp files are allowed");

        RuleFor(x => x.Image)
            .Must(file => file is not { Length: > 2 * 1024 * 1024 })
            .WithMessage("Image must be <= 2MB");


        When(x => x.ParentId == null, () =>
        {
            RuleFor(x => x.IconName).NotEmpty().WithMessage("Icon is required for main categories");
            // RuleFor(x => x.PropertyKeys).Empty().WithMessage("Main categories should not have property keys");
        });

        // When(x => x.ParentId != null,
        //     () => { RuleFor(x => x.PropertyKeys).NotNull().WithMessage("Subcategories must have property keys"); });
    }
}