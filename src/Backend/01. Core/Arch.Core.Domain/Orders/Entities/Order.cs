using Arch.Core.Domain.Orders.Events;
using Arch.Core.Domain.Orders.ValueObjects;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.ValueObjects;

namespace Arch.Core.Domain.Orders.Entities;

public class Order : AggregateRoot
{
    public BusinessId UserId { get; private set; } = null!;
    public Address Address { get; private set; } = null!;

    private HashSet<OrderDetail> _orderDetails = new();
    public IReadOnlyCollection<OrderDetail> OrderDetails => _orderDetails;

    private Order()
    {
    }

    public Order(BusinessId businessId, BusinessId userId, Address address, BusinessId productId, Count count)
    {
        BusinessId = businessId;
        UserId = userId;
        Address = address;

        AddOrderDetail(BusinessId, productId, count);

        AddEvent(new OrderCreated(BusinessId.Value, UserId.Value, Address.Street, Address.Plaque));
    }

    public void AddOrderDetail(BusinessId orderId, BusinessId productId, Count count)
    {
        OrderDetail orderDetail = default;

        if (_orderDetails.Any(o => o.ProductId == productId))
        {
            orderDetail = _orderDetails.First(o => o.ProductId == productId);
            orderDetail.ChangeOrderDetailProductCount(count);
            AddEvent(new OrderDetailProductAdded(orderDetail.BusinessId.Value, orderDetail.OrderId.Value, orderDetail.ProductId.Value, orderDetail.Count.Value));
        }
        else
        {
            orderDetail = new OrderDetail(Guid.NewGuid(), orderId, productId, count);
            _orderDetails.Add(orderDetail);
            AddEvent(new OrderDetailCreated(orderDetail.BusinessId.Value, orderDetail.OrderId.Value, orderDetail.ProductId.Value, orderDetail.Count.Value));
        }
    }

    public void UpdateAddress(Address address)
    {
        Address = address;

        AddEvent(new OrderAddressUpdated());
    }

    public void Remove()
    {
        AddEvent(new OrderRemoved(BusinessId.Value));
    }
}