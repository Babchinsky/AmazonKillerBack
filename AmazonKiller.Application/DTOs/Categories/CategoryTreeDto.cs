namespace AmazonKiller.Application.DTOs.Categories;

public record CategoryTreeDto(
    Guid Id,
    string Name,
    string Status,
    List<CategoryTreeDto> Children);