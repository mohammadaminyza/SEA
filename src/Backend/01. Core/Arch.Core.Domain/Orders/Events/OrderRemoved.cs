using Zamin.Core.Domain.Events;

namespace Arch.Core.Domain.Orders.Events;

public class OrderRemoved : IDomainEvent
{
    public Guid BusinessId { get; private set; }

    public OrderRemoved(Guid businessId)
    {
        BusinessId = businessId;
    }
}