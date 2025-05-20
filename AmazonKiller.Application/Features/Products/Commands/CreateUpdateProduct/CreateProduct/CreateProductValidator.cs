using AmazonKiller.Application.Features.Products.Commands.CreateUpdateProduct.Common;

namespace AmazonKiller.Application.Features.Products.Commands.CreateUpdateProduct.CreateProduct;

public class CreateProductValidator : UpsertProductValidator<CreateProductCommand>
{
    public CreateProductValidator() : base()
    {
    }
}