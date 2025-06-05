using MediatR;

namespace AmazonKiller.Application.Features.Categories.Admin.Queries.IsCategoryExistsAdmin;

public record IsCategoryExistsAdminQuery(Guid Id) : IRequest<bool>;