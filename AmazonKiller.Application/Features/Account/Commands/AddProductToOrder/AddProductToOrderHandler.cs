using AmazonKiller.Application.Interfaces.Repositories.Account;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.AddProductToOrder;

public class AddProductToOrderHandler(IOrderRepository repo) : IRequestHandler<AddProductToOrderCommand>
{
    public async Task Handle(AddProductToOrderCommand request, CancellationToken ct)
    {
        await repo.AddProductToOrderAsync(request.OrderId, request.ProductId, request.Quantity, ct);
    }
}