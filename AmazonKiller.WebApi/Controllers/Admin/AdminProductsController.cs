using AmazonKiller.Application.Features.Products.Admin.Commands.BulkDeleteProducts;
using AmazonKiller.Application.Features.Products.Admin.Commands.CreateUpdateProduct.CreateProduct;
using AmazonKiller.Application.Features.Products.Admin.Commands.CreateUpdateProduct.UpdateProduct;
using AmazonKiller.Application.Features.Products.Admin.Queries.GetAllProductsAdmin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Admin;

[ApiController]
[Route("api/admin/products")]
[Authorize(Roles = "Admin")]
public class AdminProductsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProductsAdminQuery q, CancellationToken ct)
    {
        var list = await mediator.Send(q, ct);
        return Ok(list);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromForm] CreateProductCommand cmd, CancellationToken ct)
    {
        var result = await mediator.Send(cmd, ct);
        return CreatedAtAction("GetById", "Products", new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(Guid id, [FromForm] UpdateProductCommand cmd, CancellationToken ct)
    {
        if (id != cmd.Id) return Problem("ID mismatch");

        var dto = await mediator.Send(cmd, ct);
        return Ok(dto);
    }

    [HttpPost("delete-many")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> BulkDelete([FromBody] BulkDeleteProductsCommand cmd, CancellationToken ct)
    {
        var result = await mediator.Send(cmd, ct);
        return Ok(result);
    }
}