using Arch.Core.Domain.Orders.Events;
using Arch.Core.Domain.Orders.ValueObjects;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.ValueObjects;

namespace Arch.Core.Domain.Orders.Entities;

public class Order : AggregateRoot<int>
{
    public BusinessId UserId { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public Tax Tax { get; private set; } = null!;


    private HashSet<OrderDetail> _orderDetails = new();
    public IReadOnlyCollection<OrderDetail> OrderDetails => _orderDetails;

    private Order()
    {
    }

    public Order(BusinessId businessId, BusinessId userId, Address address, Tax tax, BusinessId productId, Count count)
    {
        BusinessId = businessId;
        UserId = userId;
        Tax = tax;
        Address = address;

        AddOrderDetail(productId, count);

        AddEvent(new OrderCreated(BusinessId.Value, UserId.Value, Address.Street, Address.Plaque));
    }

    public void AddOrderDetail(BusinessId productId, Count count)
    {
        OrderDetail orderDetail = default;

        if (_orderDetails.Any(o => o.ProductId == productId))
        {
            orderDetail = _orderDetails.First(o => o.ProductId == productId);
            orderDetail.ChangeOrderDetailProductCount(count);
            AddEvent(new OrderDetailProductAdded(orderDetail.BusinessId.Value, orderDetail.OrderId, orderDetail.ProductId.Value, orderDetail.Count.Value));
        }
        else
        {
            orderDetail = new OrderDetail(Guid.NewGuid(), productId, count);
            _orderDetails.Add(orderDetail);
            AddEvent(new OrderDetailCreated(orderDetail.BusinessId.Value, orderDetail.OrderId, orderDetail.ProductId.Value, orderDetail.Count.Value));
        }
    }

    public void UpdateAddress(Address address)
    {
        Address = address;

        AddEvent(new OrderAddressUpdated());
    }

    public void ApplyTax(Tax tax)
    {
        Tax = tax;
        // Todo AddEvent and etc...
    }

    public void Remove()
    {
        AddEvent(new OrderRemoved(BusinessId.Value));
    }
}