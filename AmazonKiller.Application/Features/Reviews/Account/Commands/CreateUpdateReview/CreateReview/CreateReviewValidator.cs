using AmazonKiller.Application.Features.Reviews.Account.Commands.CreateUpdateReview.Common;
using FluentValidation;

namespace AmazonKiller.Application.Features.Reviews.Account.Commands.CreateUpdateReview.CreateReview;

public class CreateReviewValidator : UpsertReviewValidator<CreateReviewCommand>
{
    public CreateReviewValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
    }
}