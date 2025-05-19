using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.RowVersion).NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .PrecisionScale(18, 2, true);

        RuleFor(x => x.Quantity)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.CategoryId)
            .NotEmpty();

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

        RuleForEach(x => x.NewImages)
            .Must(BeValidImageType)
            .WithMessage("Only .jpg, .jpeg, .png, .webp files are allowed");

        RuleForEach(x => x.NewImages)
            .Must(file => file.Length <= 2 * 1024 * 1024)
            .WithMessage("Each image must be <= 2MB");

        RuleFor(x => x)
            .Must(x => x.ExistingImageUrls.Count + x.NewImages.Count > 0)
            .WithMessage("At least one image (existing or new) is required");

        RuleFor(x => x)
            .Must(x => x.ExistingImageUrls.Count + x.NewImages.Count <= 20)
            .WithMessage("Maximum 20 images allowed (existing + new)");
    }

    private static bool BeValidImageType(IFormFile file)
    {
        var allowed = new[] { ".jpg", ".jpeg", ".png", ".webp" };
        var ext = Path.GetExtension(file.FileName).ToLower();
        return allowed.Contains(ext);
    }
}