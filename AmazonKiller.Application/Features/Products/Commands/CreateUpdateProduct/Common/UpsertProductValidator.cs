namespace AmazonKiller.Application.Features.Products.Commands.CreateUpdateProduct.Common;

using FluentValidation;

public abstract class UpsertProductValidator<T> : AbstractValidator<T>
    where T : UpsertProductModel
{
    protected UpsertProductValidator()
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
                f.RuleFor(a => a.Name).NotEmpty().MaximumLength(60);
                f.RuleFor(a => a.Description).NotEmpty().MaximumLength(300);
            });

        RuleFor(x => x.Images)
            .NotEmpty().WithMessage("At least one image is required")
            .Must(list => list.Count <= 10)
            .WithMessage("Maximum 10 images allowed");

        RuleForEach(x => x.Images)
            .Must(file => new[] { ".jpg", ".jpeg", ".png", ".webp" }
                .Contains(Path.GetExtension(file.FileName).ToLower()))
            .WithMessage("Only .jpg, .jpeg, .png, .webp files are allowed");

        RuleForEach(x => x.Images)
            .Must(file => file.Length <= 2 * 1024 * 1024)
            .WithMessage("Each image must be <= 2MB");
    }
}