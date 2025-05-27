using AmazonKiller.Application.DTOs.Categories;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Admin.Queries.GetAllCategoriesAdmin;

public class GetAllCategoriesAdminQuery : IRequest<List<CategoryDto>>;