using FluentValidation;

namespace AmazonKiller.Application.Features.Categories.Admin.Commands.CreateUpdateCategory.UpdateCategory;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Category ID is required");

        RuleFor(x => x.RowVersion)
            .NotEmpty()
            .WithMessage("RowVersion is required.");

        RuleFor(x => x.ActivePropertyKeys)
            .Must(keys => keys?.Distinct().Count() == keys?.Count)
            .WithMessage("Active property keys must be unique");
    }
}