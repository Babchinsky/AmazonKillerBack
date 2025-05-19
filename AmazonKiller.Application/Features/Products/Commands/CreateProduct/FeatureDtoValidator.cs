using AmazonKiller.Application.DTOs.Products;
using FluentValidation;

namespace AmazonKiller.Application.Features.Products.Commands.CreateProduct;

public class FeatureDtoValidator : AbstractValidator<ProductFeatureDto>
{
    public FeatureDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
    }
}