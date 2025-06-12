using AmazonKiller.Application.Features.Categories.Admin.Commands.CreateUpdateCategory.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Admin.Commands.CreateUpdateCategory.UpdateCategory;

public class UpdateCategoryCommand : UpsertCategoryModel, IRequest<Guid>
{
    public Guid Id { get; init; }
    public List<string>? ActivePropertyKeys { get; init; }
    public string RowVersion { get; init; } = string.Empty;
}