using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Queries.GetReviewCount;

public record GetReviewCountQuery(Guid ProductId) : IRequest<int>;