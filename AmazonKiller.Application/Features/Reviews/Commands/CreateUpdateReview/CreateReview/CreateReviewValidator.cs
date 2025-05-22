using AmazonKiller.Application.Features.Reviews.Commands.CreateUpdateReview.Common;
using FluentValidation;

namespace AmazonKiller.Application.Features.Reviews.Commands.CreateUpdateReview.CreateReview;

public class CreateReviewValidator : UpsertReviewValidator<CreateReviewCommand>
{
    public CreateReviewValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
    }
}