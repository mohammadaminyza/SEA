namespace Arch.Core.Domain.Orders.Events;

public class OrderRemoved
{
    public Guid BusinessId { get; private set; }

    public OrderRemoved(Guid businessId)
    {
        BusinessId = businessId;
    }
}