using AmazonKiller.Application.Features.Reviews.Account.Commands.CreateUpdateReview.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Account.Commands.CreateUpdateReview.CreateReview;

public class CreateReviewCommand : UpsertReviewModel, IRequest<Guid>
{
    public Guid ProductId { get; init; }
}