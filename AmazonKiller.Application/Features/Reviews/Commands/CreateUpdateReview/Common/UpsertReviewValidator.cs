using FluentValidation;

namespace AmazonKiller.Application.Features.Reviews.Commands.CreateUpdateReview.Common;

public class UpsertReviewValidator<T> : AbstractValidator<T> where T : UpsertReviewModel
{
    protected UpsertReviewValidator()
    {
        RuleFor(x => x.Article).NotEmpty().Length(10, 40);
        RuleFor(x => x.Message).NotEmpty().Length(20, 400);
        RuleFor(x => x.Rating).InclusiveBetween(1, 5);

        RuleFor(x => x.Tags)
            .Must(tags => tags.Count <= 20)
            .WithMessage("You can add up to 20 tags.");

        RuleFor(x => x.UploadedFiles)
            .Must(files => files.Count <= 10)
            .WithMessage("You can upload up to 10 files.");

        RuleForEach(x => x.UploadedFiles).ChildRules(file =>
        {
            file.RuleFor(f => f.Length)
                .LessThanOrEqualTo(5 * 1024 * 1024)
                .WithMessage("Each file must be less than 5MB.");

            file.RuleFor(f => f.ContentType)
                .Must(type => type.StartsWith("image/") || type == "application/pdf")
                .WithMessage("Only image and PDF files are allowed.");
        });
    }
}