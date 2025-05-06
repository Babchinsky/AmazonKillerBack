using MediatR;

namespace AmazonKiller.Application.Features.Categories.Queries.IsCategoryExists;

public record IsCategoryExistsQuery(Guid Id) : IRequest<bool>;