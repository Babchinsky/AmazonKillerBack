using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Queries.GetAverageRating;

public record GetAverageRatingQuery(Guid ProductId) : IRequest<double>;