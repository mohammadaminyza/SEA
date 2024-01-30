using Zamin.Core.RequestResponse.Commands;

namespace Arch.Core.Contracts.Orders.Commands.UpdateOrderAddress;

public class UpdateOrderAddressCommand : ICommand
{
    public int OrderId { get; set; }
    public string Street { get; set; } = null!;
    public string Plaque { get; set; } = null!;
}