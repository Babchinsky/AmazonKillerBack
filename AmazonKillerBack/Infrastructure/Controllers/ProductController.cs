using AmazonKillerBack.Application.Features.Products.Create;
using AmazonKillerBack.Application.Features.Products.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKillerBack.Infrastructure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
    }
}
