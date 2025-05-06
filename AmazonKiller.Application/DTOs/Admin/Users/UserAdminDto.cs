namespace AmazonKiller.Application.DTOs.Admin.Users;

public record UserAdminDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Role,
    string Status,
    DateTime CreatedAt);