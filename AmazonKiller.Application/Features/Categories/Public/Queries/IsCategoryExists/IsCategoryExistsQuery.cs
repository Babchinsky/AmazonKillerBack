using MediatR;

namespace AmazonKiller.Application.Features.Categories.Public.Queries.IsCategoryExists;

public record IsCategoryExistsQuery(Guid Id) : IRequest<bool>;