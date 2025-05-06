using FluentValidation;

namespace AmazonKiller.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.ImageUrls)
            .NotNull()
            .Must(p => p.Count <= 20)
            .WithMessage("Product can have up to 20 pictures");

        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(2, 100);

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .PrecisionScale(18, 2, true); // ← заменили ScalePrecision на PrecisionScale

        RuleFor(x => x.Quantity)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.CategoryId)
            .NotEmpty();
    }
}