using AmazonKiller.Application.DTOs.Reviews;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Queries.GetReviewById;

public record GetReviewByIdQuery(Guid Id) : IRequest<ReviewDto>;