using AmazonKiller.Application.Features.Reviews.Commands.CreateUpdateReview.Common;
using FluentValidation;

namespace AmazonKiller.Application.Features.Reviews.Commands.CreateUpdateReview.UpdateReview;

public class UpdateReviewValidator : UpsertReviewValidator<UpdateReviewCommand>
{
    public UpdateReviewValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.RowVersion)
            .NotEmpty()
            .WithMessage("RowVersion is required for concurrency check");
    }
}