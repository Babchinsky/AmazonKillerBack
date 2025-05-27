using FluentValidation;

namespace AmazonKiller.Application.Features.Categories.Admin.Commands.BulkDeleteCategories;

public class BulkDeleteCategoriesValidator : AbstractValidator<BulkDeleteCategoriesCommand>
{
    public BulkDeleteCategoriesValidator()
    {
        RuleFor(x => x.Ids).NotEmpty().WithMessage("Must contain at least one category ID");
    }
}