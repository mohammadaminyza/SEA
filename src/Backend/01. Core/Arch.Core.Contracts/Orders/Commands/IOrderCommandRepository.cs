using Arch.Core.Domain.Orders.Entities;
using Zamin.Core.Contracts.Data.Commands;

namespace Arch.Core.Contracts.Orders.Commands;

public interface IOrderCommandRepository : ICommandRepository<Order, int>
{
}