using AmazonKiller.Application.Features.Categories.Admin.Commands.BulkDeleteCategories;
using AmazonKiller.Application.Features.Categories.Admin.Commands.CreateUpdateCategory.CreateCategory;
using AmazonKiller.Application.Features.Categories.Admin.Commands.CreateUpdateCategory.UpdateCategory;
using AmazonKiller.Application.Features.Categories.Admin.Queries.GetAllCategoriesAdmin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Admin;

[ApiController]
[Route("api/admin/categories")]
[Authorize(Roles = "Admin")]
public class AdminCategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var result = await mediator.Send(new GetAllCategoriesAdminQuery(), ct);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateCategoryCommand cmd, CancellationToken ct)
    {
        var result = await mediator.Send(cmd, ct);
        return CreatedAtAction("GetById", "Categories", new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromForm] UpdateCategoryCommand cmd, CancellationToken ct)
    {
        if (id != cmd.Id) return Problem("ID mismatch");
        var updated = await mediator.Send(cmd, ct);
        return Ok(updated);
    }

    [HttpPost("delete-many")]
    public async Task<IActionResult> BulkDelete([FromBody] BulkDeleteCategoriesCommand cmd, CancellationToken ct)
    {
        var result = await mediator.Send(cmd, ct);
        return Ok(result);
    }
}