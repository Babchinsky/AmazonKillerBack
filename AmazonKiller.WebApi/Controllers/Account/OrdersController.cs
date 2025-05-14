using AmazonKiller.Application.Features.Account.Orders.Commands.AddProductToOrder;
using AmazonKiller.Application.Features.Account.Orders.Commands.CreateOrder;
using AmazonKiller.Application.Features.Account.Orders.Commands.RemoveProductFromOrder;
using AmazonKiller.Application.Features.Account.Orders.Queries.GetOrderDetails;
using AmazonKiller.Application.Features.Account.Orders.Queries.GetOrders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Account;

[ApiController]
[Route("api/orders")]
[Authorize]
public class OrdersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await mediator.Send(new GetOrdersQuery());
        return Ok(orders);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var details = await mediator.Send(new GetOrderDetailsQuery(id));
        return Ok(details);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
    {
        var id = await mediator.Send(command);
        return Ok(id);
    }

    [HttpPost("/products")]
    public async Task<IActionResult> AddProduct([FromBody] AddProductToOrderCommand cmd,
        CancellationToken ct)
    {
        await mediator.Send(cmd, ct);
        return NoContent();
    }

    [HttpDelete("{orderId:guid}/products/{productId:guid}")]
    public async Task<IActionResult> RemoveProduct(Guid orderId, Guid productId, CancellationToken ct)
    {
        await mediator.Send(new RemoveProductFromOrderCommand(orderId, productId), ct);
        return NoContent();
    }
}