namespace Arch.Core.Contracts.Orders.Commands.CreateOrder;

public class InitializeOrderDetail
{
    public Guid ProductId { get; set; }
    public int Count { get; set; } = 1;

}