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

        RuleForEach(x => x.ParsedAttributes)
            .ChildRules(attr =>
            {
                attr.RuleFor(a => a.Key).NotEmpty().MaximumLength(30);
                attr.RuleFor(a => a.Value).NotEmpty().MaximumLength(30);
            });

        RuleForEach(x => x.ParsedFeatures)
            .ChildRules(f =>
            {
                f.RuleFor(p => p.Name).NotEmpty().MaximumLength(60);
                f.RuleFor(p => p.Description).NotEmpty().MaximumLength(300);
            });

        RuleForEach(x => x.Images)
            .Must(file => new[] { ".jpg", ".jpeg", ".png", ".webp" }
                .Contains(Path.GetExtension(file.FileName).ToLower()))
            .WithMessage("Only .jpg, .jpeg, .png, .webp files are allowed");

        RuleForEach(x => x.Images)
            .Must(file => file.Length <= 2 * 1024 * 1024)
            .WithMessage("Each image must be <= 2MB");


        RuleFor(x => x.Images)
            .NotEmpty().WithMessage("Хотя бы одно изображение обязательно")
            .Must(list => list.Count <= 10)
            .WithMessage("Максимум 10 изображений");
    }
}