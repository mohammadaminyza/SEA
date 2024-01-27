using Arch.Core.Domain.Orders.ValueObjects;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace Arch.Core.Domain.Orders.Entities;

public class OrderDetail : Entity
{
    public BusinessId OrderId { get; private set; } = null!;
    public BusinessId ProductId { get; private set; } = null!;
    public Count Count { get; private set; } = null!;

    private OrderDetail()
    {
    }

    public OrderDetail(BusinessId businessId, BusinessId orderId, BusinessId productId, Count count)
    {
        BusinessId = businessId;
        OrderId = orderId;
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