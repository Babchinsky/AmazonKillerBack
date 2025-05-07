using FluentValidation;

namespace AmazonKiller.Application.Features.Products.Commands.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.CategoryId).NotEmpty();
        RuleFor(x => x.DetailsId).NotEmpty();
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
        RuleForEach(x => x.ImageUrls).NotEmpty().MaximumLength(300);

        // Вложенные валидации для AttributeDto и FeatureDto:
        RuleForEach(x => x.Attributes).SetValidator(new AttributeDtoValidator());
        RuleForEach(x => x.Features).SetValidator(new FeatureDtoValidator());
    }
}