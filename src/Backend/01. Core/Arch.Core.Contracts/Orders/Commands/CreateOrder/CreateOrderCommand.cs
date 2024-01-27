using Zamin.Core.RequestResponse.Commands;

namespace Arch.Core.Contracts.Orders.Commands.CreateOrder;

public class CreateOrderCommand : ICommand
{
    public Guid UserId { get; set; }
    public string Street { get; set; } = null!;
    public string Plaque { get; set; } = null!;
    public InitializeOrderDetail OrderDetail { get; set; } = new();
}