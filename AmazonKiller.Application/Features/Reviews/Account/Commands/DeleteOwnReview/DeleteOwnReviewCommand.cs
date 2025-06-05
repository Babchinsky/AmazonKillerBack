using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Account.Commands.DeleteOwnReview;

public record DeleteOwnReviewCommand(Guid Id) : IRequest<bool>;