using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Features.Categories.Commands.CreateUpdateCategory.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Commands.CreateUpdateCategory.CreateCategory;

public class CreateCategoryCommand : UpsertCategoryModel, IRequest<CategoryDto>;