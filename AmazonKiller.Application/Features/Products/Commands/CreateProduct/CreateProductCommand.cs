using AmazonKiller.Application.DTOs.Products;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Features.Products.Commands.CreateProduct;

/// <summary>
/// Команда создания товара; приходит из WebAPI-слоя через AutoMapper.
/// </summary>
public record CreateProductCommand(
    string Code,
    string Name,
    Guid CategoryId,
    decimal Price,
    decimal? DiscountPct,
    int Quantity,
    List<IFormFile> Images,
    List<ProductAttributeDto> Attributes,
    List<ProductFeatureDto> Features
) : IRequest<Guid>;