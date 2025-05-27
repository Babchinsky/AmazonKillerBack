using FluentValidation;

namespace AmazonKiller.Application.Features.Orders.Admin.Commands.ChangeOrderStatus;

public class ChangeOrderStatusValidator : AbstractValidator<ChangeOrderStatusCommand>
{
    public ChangeOrderStatusValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty();
        RuleFor(x => x.NewStatus).IsInEnum();
    }
}