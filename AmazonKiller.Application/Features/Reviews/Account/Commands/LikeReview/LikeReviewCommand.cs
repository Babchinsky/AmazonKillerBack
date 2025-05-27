using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Account.Commands.LikeReview;

public record LikeReviewCommand(Guid ReviewId) : IRequest<Unit>;