using AmazonKiller.Application.Features.Filters.Queries;
using AmazonKiller.Application.Features.Products.Commands.BulkDeleteProducts;
using AmazonKiller.Application.Features.Products.Commands.CreateProduct;
using AmazonKiller.Application.Features.Products.Commands.UpdateProduct;
using AmazonKiller.Application.Features.Products.Queries.GetAllProducts;
using AmazonKiller.Application.Features.Products.Queries.GetProductById;
using AmazonKiller.Application.Features.Products.Queries.IsProductExists;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Получить все продукты с фильтрацией, сортировкой и пагинацией
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQuery q, CancellationToken ct)
    {
        var list = await mediator.Send(q, ct);
        return Ok(list);
    }

    /// <summary>
    /// Получить продукт по ID
    /// </summary>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken ct)
    {
        var dto = await mediator.Send(new GetProductByIdQuery(id), ct);
        return Ok(dto);
    }

    /// <summary>
    /// Проверить, существует ли продукт по ID
    /// </summary>
    [HttpGet("{id:guid}/exists")]
    public async Task<IActionResult> Exists(Guid id, CancellationToken ct)
    {
        var exists = await mediator.Send(new IsProductExistsQuery(id), ct);
        return Ok(exists);
    }

    /// <summary>
    /// Создать новый продукт
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateProductCommand cmd, CancellationToken ct)
    {
        var id = await mediator.Send(cmd, ct);
        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    /// <summary>
    /// Обновить существующий продукт
    /// </summary>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand cmd, CancellationToken ct)
    {
        if (id != cmd.Id)
            return BadRequest("ID mismatch");

        var dto = await mediator.Send(cmd, ct);
        return Ok(dto);
    }

    /// <summary>
    /// Удалить несколько продуктов по их ID
    /// </summary>
    [HttpPost("delete-many")]
    public async Task<IActionResult> BulkDelete([FromBody] BulkDeleteProductsCommand cmd, CancellationToken ct)
    {
        var result = await mediator.Send(cmd, ct);
        return Ok(result);
    }

    /// <summary>
    /// Получить доступные фильтры для выбранной категории
    /// </summary>
    [HttpGet("filters")]
    public async Task<IActionResult> GetFilters([FromQuery] Guid categoryId, CancellationToken ct)
    {
        var result = await mediator.Send(new GetAvailableFiltersQuery(categoryId), ct);
        return Ok(result);
    }
}