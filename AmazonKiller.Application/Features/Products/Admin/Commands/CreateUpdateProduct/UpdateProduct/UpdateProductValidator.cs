using AmazonKiller.Application.Features.Products.Admin.Commands.CreateUpdateProduct.Common;
using FluentValidation;

namespace AmazonKiller.Application.Features.Products.Admin.Commands.CreateUpdateProduct.UpdateProduct;

public class UpdateProductValidator : UpsertProductValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Product ID is required");

        RuleFor(x => x.RowVersion)
            .NotEmpty()
            .WithMessage("RowVersion is required.");
    }
}