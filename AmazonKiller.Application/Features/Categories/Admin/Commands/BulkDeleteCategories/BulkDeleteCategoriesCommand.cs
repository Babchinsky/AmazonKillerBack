using AmazonKiller.Application.DTOs.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Admin.Commands.BulkDeleteCategories;

public record BulkDeleteCategoriesCommand(List<Guid> Ids) : IRequest<BulkDeleteResultDto>;