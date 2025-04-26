using FluentValidation;

namespace AmazonKiller.Application.Features.Products.Commands.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.ProductPics).Must(p => p.Count <= 20);
        RuleFor(x => x.Name).NotEmpty().Length(2, 100);
        RuleFor(x => x.Price).GreaterThan(0).ScalePrecision(2, 18);
        RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CategoryId).NotEmpty();
        RuleFor(x => x.DetailsId).NotEmpty();
    }
}