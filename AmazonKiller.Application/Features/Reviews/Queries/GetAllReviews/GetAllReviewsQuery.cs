using AmazonKiller.Application.DTOs.Reviews;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Queries.GetAllReviews;

public record GetAllReviewsQuery(
    Guid? ProductId,
    int? MinRating,
    int? MaxRating,
    string? SortBy,
    bool SortDesc = false,
    int Page = 1,
    int PageSize = 20
) : IRequest<List<ReviewDto>>;
