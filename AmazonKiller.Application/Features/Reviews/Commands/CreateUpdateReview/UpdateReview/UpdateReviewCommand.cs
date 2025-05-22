using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Features.Reviews.Commands.CreateUpdateReview.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Commands.CreateUpdateReview.UpdateReview;

public class UpdateReviewCommand : UpsertReviewModel, IRequest<ReviewDto>
{
    public Guid Id { get; init; }
    public string RowVersion { get; init; } = string.Empty;
}