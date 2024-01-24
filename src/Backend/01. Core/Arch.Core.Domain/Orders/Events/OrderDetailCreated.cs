using Zamin.Core.Domain.Events;

namespace Arch.Core.Domain.Orders.Events;

public class OrderDetailCreated : IDomainEvent
{
    public Guid BusinessId { get; private set; }
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Count { get; private set; }

    public OrderDetailCreated(Guid businessId, Guid orderId, Guid productId, int count)
    {
        BusinessId = businessId;
        OrderId = orderId;
        ProductId = productId;
        Count = count;
    }
}