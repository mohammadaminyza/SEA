using Arch.Core.Domain.Orders.ValueObjects;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace Arch.Core.Domain.Orders.Entities;

public class OrderDetail : Entity
{
    public int OrderId { get; private set; }
    public BusinessId ProductId { get; private set; } = null!;
    public Count Count { get; private set; } = null!;

    public Order Order { get; set; }

    private OrderDetail()
    {
    }

    public OrderDetail(BusinessId businessId, BusinessId productId, Count count)
    {
        BusinessId = businessId;
        ProductId = productId;
        Count = count;
    }

    public void ChangeOrderDetailProductCount(Count count)
    {
        if (Count == count)
            throw new InvalidEntityStateException("Count didn't changed");

        Count = count;
    }
}