using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Users;
using MediatR;

namespace AmazonKiller.Application.Features.Users.Admin.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<PagedList<UserAdminDto>>
{
    public string? Search { get; init; }
    public string? Role { get; init; }
    public string? Status { get; init; }
    public QueryParameters Parameters { get; init; } = new();
}