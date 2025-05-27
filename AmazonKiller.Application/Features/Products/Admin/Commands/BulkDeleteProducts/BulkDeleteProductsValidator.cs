using FluentValidation;

namespace AmazonKiller.Application.Features.Products.Admin.Commands.BulkDeleteProducts;

public class BulkDeleteProductsValidator : AbstractValidator<BulkDeleteProductsCommand>
{
    public BulkDeleteProductsValidator()
    {
        RuleFor(x => x.Ids).NotEmpty().WithMessage("Must contain at least one product ID");
    }
}