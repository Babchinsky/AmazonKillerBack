using AmazonKiller.Application.DTOs.Products;
using FluentValidation;

namespace AmazonKiller.Application.Features.Products.Commands.CreateProduct;

public class AttributeDtoValidator : AbstractValidator<ProductAttributeDto>
{
    public AttributeDtoValidator()
    {
        RuleFor(x => x.Key).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Value).NotEmpty().MaximumLength(100);
    }
}