using Arch.Core.Contracts.Orders.Commands;
using Arch.Core.Domain.Orders.Entities;
using Arch.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace Arch.Infra.Data.Sql.Commands.Orders;

public class OrderCommandRepository : BaseCommandRepository<Order, ArchCommandDbContext, int>, IOrderCommandRepository
{
    public OrderCommandRepository(ArchCommandDbContext dbContext) : base(dbContext)
    {
    }
}