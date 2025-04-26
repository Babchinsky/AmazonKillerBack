using AmazonKiller.Application.Interfaces.Repositories.Account;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.RemoveProductFromOrder;

public class RemoveProductFromOrderHandler(IOrderRepository repo) : IRequestHandler<RemoveProductFromOrderCommand>
{
    public async Task Handle(RemoveProductFromOrderCommand request, CancellationToken ct)
    {
        await repo.RemoveProductFromOrderAsync(request.OrderId, request.ProductId, ct);
    }
}