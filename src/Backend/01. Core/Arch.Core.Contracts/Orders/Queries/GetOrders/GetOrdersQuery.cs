using Zamin.Core.RequestResponse.Queries;

namespace Arch.Core.Contracts.Orders.Queries.GetOrders;

public class GetOrdersQuery : PageQuery<PagedData<OrderDto>>
{
    public string? Street { get; set; }
    public string? Plaque { get; set; }
    public Guid? UserId { get; set; }
}