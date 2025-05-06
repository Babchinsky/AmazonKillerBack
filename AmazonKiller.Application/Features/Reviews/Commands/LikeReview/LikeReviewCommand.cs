using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Commands.LikeReview;

public record LikeReviewCommand(Guid ReviewId) : IRequest<Unit>;