using AmazonKiller.Application.Common.Models;
using AmazonKiller.Domain.Entities.Orders;

namespace AmazonKiller.Application.Features.Orders.Common;

public interface IOrderQueryWithFilters
{
    string? SearchTerm { get; }
    OrderStatus? Status { get; }
    QueryParameters Parameters { get; }
}