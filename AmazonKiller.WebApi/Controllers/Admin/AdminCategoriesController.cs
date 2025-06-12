using AmazonKiller.Application.Features.Categories.Admin.Commands.BulkDeleteCategories;
using AmazonKiller.Application.Features.Categories.Admin.Commands.CreateUpdateCategory.CreateCategory;
using AmazonKiller.Application.Features.Categories.Admin.Commands.CreateUpdateCategory.UpdateCategory;
using AmazonKiller.Application.Features.Categories.Admin.Queries.GetAllCategoriesAdmin;
using AmazonKiller.Application.Features.Categories.Admin.Queries.GetCategoryByIdAdmin;
using AmazonKiller.Application.Features.Categories.Admin.Queries.GetCategoryPropertyKeysByIdAdmin;
using AmazonKiller.Application.Features.Categories.Admin.Queries.IsCategoryExistsAdmin;
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
    public async Task<IActionResult> GetAll([FromQuery] GetAllCategoriesAdminQuery query, CancellationToken ct)
    {
        var result = await mediator.Send(query, ct);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var dto = await mediator.Send(new GetCategoryByIdAdminQuery(id), ct); // admin version
        return Ok(dto);
    }

    [HttpGet("{id:guid}/exists")]
    public Task<bool> Exists(Guid id, CancellationToken ct)
    {
        return mediator.Send(new IsCategoryExistsAdminQuery(id), ct);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateCategoryCommand cmd, CancellationToken ct)
    {
        var id = await mediator.Send(cmd, ct);
        var dto = await mediator.Send(new GetCategoryByIdAdminQuery(id), ct);
        
        return CreatedAtAction(nameof(GetById), new { id }, dto);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromForm] UpdateCategoryCommand cmd, CancellationToken ct)
    {
        if (id != cmd.Id) return Problem("ID mismatch");

        var resultId = await mediator.Send(cmd, ct);
        var updatedDto = await mediator.Send(new GetCategoryByIdAdminQuery(resultId), ct);
        return Ok(updatedDto);
    }

    [HttpPost("delete-many")]
    public async Task<IActionResult> BulkDelete([FromBody] BulkDeleteCategoriesCommand cmd, CancellationToken ct)
    {
        var result = await mediator.Send(cmd, ct);
        return Ok(result);
    }

    [HttpGet("{id:guid}/property-keys")]
    public async Task<IActionResult> GetPropertyKeys(Guid id, CancellationToken ct)
    {
        var result = await mediator.Send(new GetCategoryPropertyKeysByIdAdminQuery(id), ct);
        return Ok(result);
    }
}