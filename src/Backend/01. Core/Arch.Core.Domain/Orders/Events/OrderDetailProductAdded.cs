using Zamin.Core.Domain.Events;

namespace Arch.Core.Domain.Orders.Events;

public class OrderDetailProductAdded : IDomainEvent
{
    public Guid BusinessId { get; private set; }
    public int OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Count { get; private set; }

    public OrderDetailProductAdded(Guid businessId, int orderId, Guid productId, int count)
    {
        BusinessId = businessId;
        OrderId = orderId;
        ProductId = productId;
        Count = count;
    }
}