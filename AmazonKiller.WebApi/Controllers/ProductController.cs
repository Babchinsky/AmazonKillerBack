using AmazonKiller.Application.Features.Products.Commands.BulkDeleteProducts;
using AmazonKiller.Application.Features.Products.Commands.CreateProduct;
using AmazonKiller.Application.Features.Products.Commands.DeleteProduct;
using AmazonKiller.Application.Features.Products.Commands.UpdateProduct;
using AmazonKiller.Application.Features.Products.Queries.GetAllProducts;
using AmazonKiller.Application.Features.Products.Queries.GetProductById;
using AmazonKiller.Application.Features.Products.Queries.IsProductExists;
using AmazonKiller.Application.Interfaces.Common;
using AmazonKiller.WebApi.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var isExists = await mediator.Send(new IsProductExistsQuery(id));
        if (!isExists)
            return NotFound();

        await mediator.Send(new DeleteProductCommand(id));
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand cmd)
    {
        if (id != cmd.Id)
            return BadRequest("Id mismatch");

        var isExists = await mediator.Send(new IsProductExistsQuery(id));
        if (!isExists)
            return NotFound();

        var updated = await mediator.Send(cmd);
        return Ok(updated);
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("bulk-delete")]
    public async Task<IActionResult> BulkDelete([FromBody] BulkDeleteProductsCommand cmd, CancellationToken ct)
    {
        await mediator.Send(cmd, ct);
        return NoContent();
    }
}