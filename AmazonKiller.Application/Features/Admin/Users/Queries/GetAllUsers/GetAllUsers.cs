using AmazonKiller.Application.DTOs.Admin.Users;
using MediatR;

namespace AmazonKiller.Application.Features.Admin.Users.Queries.GetAllUsers;

public record GetAllUsersQuery(string? Search, string? Role) : IRequest<List<UserAdminDto>>;