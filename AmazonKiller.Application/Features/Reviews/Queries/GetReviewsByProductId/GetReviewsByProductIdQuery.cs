using AmazonKiller.Application.DTOs.Reviews;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Queries.GetReviewsByProductId;

public record GetReviewsByProductIdQuery(Guid ProductId, int Page = 1, int PageSize = 20) : IRequest<List<ReviewDto>>;