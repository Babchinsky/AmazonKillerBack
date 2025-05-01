using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Queries.IsReviewExists;

public record IsReviewExistsQuery(Guid Id) : IRequest<bool>;
