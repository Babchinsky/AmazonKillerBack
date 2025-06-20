using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Reviews;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Public.Queries.GetAllReviews;

public class GetAllReviewsQuery : IRequest<PagedList<ReviewDto>>
{
    public Guid? ProductId { get; init; }
    public Guid? UserId { get; init; }
    public int? MinRating { get; init; }
    public int? MaxRating { get; init; }
    public QueryParameters Parameters { get; init; } = new();
}