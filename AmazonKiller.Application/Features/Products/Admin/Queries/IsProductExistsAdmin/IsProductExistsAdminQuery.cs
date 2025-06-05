using MediatR;

namespace AmazonKiller.Application.Features.Products.Admin.Queries.IsProductExistsAdmin;

public record IsProductExistsAdminQuery(Guid Id) : IRequest<bool>;