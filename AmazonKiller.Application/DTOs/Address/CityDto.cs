namespace AmazonKiller.Application.DTOs.Address;

public record CityDto
{
    public string Description { get; init; } = string.Empty;
    public string Ref { get; init; } = string.Empty;
}