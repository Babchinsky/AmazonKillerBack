using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Features.Reviews.Commands.CreateUpdateReview.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Commands.CreateUpdateReview.CreateReview;

public class CreateReviewCommand : UpsertReviewModel, IRequest<ReviewDto>
{
    public Guid ProductId { get; init; }
}