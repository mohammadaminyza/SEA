using Zamin.Core.Domain.Events;

namespace Arch.Core.Domain.Orders.Events;

public class OrderCreated : IDomainEvent
{
    public Guid BusinessId { get; private set; }
    public Guid UserId { get; private set; }
    public string Street { get; private set; }
    public string Plaque { get; private set; }

    public OrderCreated(Guid businessId, Guid userId, string street, string plaque)
    {
        BusinessId = businessId;
        UserId = userId;
        Street = street;
        Plaque = plaque;
    }
}