using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Account.Commands.DeleteReview;

public record DeleteReviewCommand(Guid Id) : IRequest<bool>;