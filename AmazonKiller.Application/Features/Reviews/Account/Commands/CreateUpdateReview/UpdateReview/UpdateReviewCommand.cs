using AmazonKiller.Application.Features.Reviews.Account.Commands.CreateUpdateReview.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Account.Commands.CreateUpdateReview.UpdateReview;

public class UpdateReviewCommand : UpsertReviewModel, IRequest<Guid>
{
    public Guid Id { get; init; }
    public string RowVersion { get; init; } = string.Empty;
}