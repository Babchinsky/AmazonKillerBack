using AmazonKiller.Application.Features.Products.Create;
using AmazonKiller.Application.Features.Products.Delete;
using AmazonKiller.Application.Features.Products.GetAll;
using AmazonKiller.Application.Features.Products.GetById;
using AmazonKiller.Application.Features.Products.IsExists;
using AmazonKiller.Application.Features.Products.Update;
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
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
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
}