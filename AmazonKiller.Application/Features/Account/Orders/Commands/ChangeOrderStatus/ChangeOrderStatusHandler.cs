using AmazonKiller.Application.Interfaces.Repositories.Account;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Orders.Commands.ChangeOrderStatus;

public class ChangeOrderStatusHandler(IOrderRepository repo)
    : IRequestHandler<ChangeOrderStatusCommand>
{
    public async Task Handle(ChangeOrderStatusCommand cmd, CancellationToken ct)
    {
        await repo.UpdateOrderStatusAsync(cmd.OrderId, cmd.NewStatus, ct);
    }
}