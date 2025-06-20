﻿namespace AmazonKiller.Application.DTOs.Products;

public record ProductDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public decimal Rating { get; init; }
    public string Code { get; init; } = string.Empty;
    public int ReviewsCount { get; init; }
    public List<string> ImageUrls { get; init; } = [];
    public Guid CategoryId { get; init; }
    public string CategoryName { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public decimal? DiscountPercent { get; init; }
    public int Quantity { get; init; }
    public int SoldCount { get; init; }
    public IReadOnlyCollection<ProductAttributeDto> Attributes { get; init; } = [];
    public IReadOnlyCollection<ProductFeatureDto> Features { get; init; } = [];
    public string RowVersion { get; init; } = string.Empty;
}