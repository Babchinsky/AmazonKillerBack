using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Commands.DeleteReview;

public record DeleteReviewCommand(Guid Id) : IRequest<bool>;