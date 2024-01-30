using Zamin.Core.RequestResponse.Commands;

namespace Arch.Core.Contracts.Orders.Commands.AddOrderDetail;

public class AddOrderDetailCommand : ICommand
{
    public int OrderId { get; set; }
    public Guid ProductId { get; set; }
    public string Street { get; set; } = null!;
    public string Plaque { get; set; } = null!;
    public int Count { get; set; }
}