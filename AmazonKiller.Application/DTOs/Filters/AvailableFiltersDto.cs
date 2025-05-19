namespace AmazonKiller.Application.DTOs.Filters;

public record AvailableFiltersDto(Dictionary<string, List<string>> Filters);