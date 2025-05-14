using AmazonKiller.Application.DTOs.Common;
using AmazonKiller.Application.Features.Products.Commands.BulkDeleteProducts;
using AmazonKiller.Application.Features.Products.Commands.CreateProduct;
using AmazonKiller.Application.Features.Products.Commands.UpdateProduct;
using AmazonKiller.Application.Features.Products.Queries.GetAllProducts;
using AmazonKiller.Application.Features.Products.Queries.GetProductById;
using AmazonKiller.Application.Features.Products.Queries.IsProductExists;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CreateProductRequest = AmazonKiller.WebApi.Requests.CreateProductRequest;

namespace AmazonKiller.WebApi.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] GetAllProductsQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await mediator.Send(new GetProductByIdQuery(id));
        return Ok(product);
    }

    [HttpGet("{id:guid}/exists")]
    public async Task<IActionResult> IsExists(Guid id)
    {
        var exists = await mediator.Send(new IsProductExistsQuery(id));
        return Ok(exists);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateProductRequest req,
        [FromServices] IFileStorage files,
        CancellationToken ct)
    {
        var urls = new List<string>();
        foreach (var file in req.Images)
        {
            await using var stream = file.OpenReadStream();
            var url = await files.SaveAsync(stream, Path.GetExtension(file.FileName), ct);
            urls.Add(url);
        }

        var cmd = new CreateProductCommand(
            req.Name, req.CategoryId, req.DetailsId, req.Price, req.Quantity,
            req.Discount, urls, req.Attributes, req.Features);

        var dto = await mediator.Send(cmd, ct);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand cmd)
    {
        if (id != cmd.Id)
            return this.ProblemBadRequest("ID mismatch");

        var isExists = await mediator.Send(new IsProductExistsQuery(id));
        if (!isExists)
            return this.ProblemNotFound($"Entity with ID {id} not found");

        var updated = await mediator.Send(cmd);
        return Ok(updated);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("delete-many")]
    [ProducesResponseType(typeof(BulkDeleteResultDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> BulkDelete([FromBody] BulkDeleteProductsCommand cmd, CancellationToken ct)
    {
        var result = await mediator.Send(cmd, ct);
        return Ok(result);
    }
}