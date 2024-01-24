using Arch.Core.Contracts.Orders.Queries.GetOrders;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Core.RequestResponse.Queries;

namespace Arch.Core.Contracts.Orders.Queries;

public interface IOrderQueryRepository : IQueryRepository
{
    Task<PagedData<OrderDto>> Select(GetOrdersQuery dto);
}