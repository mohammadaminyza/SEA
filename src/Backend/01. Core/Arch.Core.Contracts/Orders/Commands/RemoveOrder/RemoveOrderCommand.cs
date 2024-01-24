using Zamin.Core.RequestResponse.Commands;

namespace Arch.Core.Contracts.Orders.Commands.RemoveOrder;

public class RemoveOrderCommand : ICommand
{
    public Guid BusinessId { get; set; }
}