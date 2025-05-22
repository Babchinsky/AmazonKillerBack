namespace AmazonKiller.Application.DTOs.Categories;

public record CategoryFiltersDto(Dictionary<string, List<string>> Filters);