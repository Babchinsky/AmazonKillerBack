using MediatR;

namespace AmazonKiller.Application.Features.Categories.Commands.BulkDeleteCategories;

public record BulkDeleteCategoriesCommand(List<Guid> Ids) : IRequest;