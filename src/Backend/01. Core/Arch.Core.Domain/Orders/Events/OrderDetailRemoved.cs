using Zamin.Core.Domain.Events;

namespace Arch.Core.Domain.Orders.Events;

public class OrderDetailRemoved : IDomainEvent
{
    public Guid BusinessId { get; private set; }

    public OrderDetailRemoved(Guid businessId)
    {
        BusinessId = businessId;
    }
}