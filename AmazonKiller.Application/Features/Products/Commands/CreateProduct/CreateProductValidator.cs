using FluentValidation;

namespace AmazonKiller.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Code).NotEmpty().MaximumLength(60);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);

        RuleForEach(x => x.Attributes)
            .ChildRules(attr =>
            {
                attr.RuleFor(a => a.Key).NotEmpty().MaximumLength(30);
                attr.RuleFor(a => a.Value).NotEmpty().MaximumLength(30);
            });

        RuleForEach(x => x.Features)
            .ChildRules(f =>
            {
                f.RuleFor(p => p.Name).NotEmpty().MaximumLength(60);
                f.RuleFor(p => p.Description).NotEmpty().MaximumLength(300);
            });

        RuleFor(x => x.Images)
            .NotEmpty().WithMessage("Хотя бы одно изображение обязательно")
            .Must(list => list.Count <= 10)
            .WithMessage("Максимум 10 изображений");
    }
}