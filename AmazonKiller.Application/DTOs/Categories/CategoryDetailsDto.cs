namespace AmazonKiller.Application.DTOs.Categories;

public class CategoryDetailsDto : CategoryDto
{
    public Dictionary<string, List<string>> Filters { get; set; } = new();
}