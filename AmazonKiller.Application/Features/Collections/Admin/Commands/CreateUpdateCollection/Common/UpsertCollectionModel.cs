using System.Text.Json;
using System.Text.Json.Serialization;
using AmazonKiller.Application.DTOs.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AmazonKiller.Application.Features.Collections.Admin.Commands.CreateUpdateCollection.Common;

public abstract record UpsertCollectionModel
{
    public string Title { get; init; } = string.Empty;
    public Guid CategoryId { get; init; }
    public decimal? MinPrice { get; init; }
    public decimal? MaxPrice { get; init; }
    public string Filters { get; init; } = "[]";

    public IFormFile? Image { get; init; }

    [JsonIgnore] // во внешнем contract'е этого поля нет
    [BindNever] // и ASP-NET не должен пытаться его биндить
    public List<CollectionFilterDto> ParsedFilters =>
        JsonSerializer.Deserialize<List<CollectionFilterDto>>(
            Filters,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        ) ?? [];
}