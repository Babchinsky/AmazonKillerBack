using AmazonKiller.Application.DTOs.Products;
using FluentValidation;

namespace AmazonKiller.Application.Features.Products.Commands.CreateProduct;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    private static readonly string[] AllowedExt = [".jpg", ".jpeg", ".png", ".webp"];
    
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(2, 100);

        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.Discount)
            .GreaterThan(0).LessThan(x => x.Price)
            .When(x => x.Discount.HasValue);

        RuleFor(x => x.Images)
            .NotEmpty().WithMessage("Нужно ≥1 фото")
            .Must(list => list.Count <= 10).WithMessage("Максимум 10 файлов");

        RuleForEach(x => x.Images)
            .Must(f => AllowedExt.Contains(Path.GetExtension(f.FileName).ToLower()))
            .WithMessage("Разрешены изображения jpg/png/webp")
            .Must(f => f.Length < 2 * 1024 * 1024) // 2 MB
            .WithMessage("Файл > 2 MB");
    }
}