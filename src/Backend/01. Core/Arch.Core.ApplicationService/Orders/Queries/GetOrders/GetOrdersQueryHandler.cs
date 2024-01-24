using Arch.Core.Contracts.Orders.Queries;
using Arch.Core.Contracts.Orders.Queries.GetOrders;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace Arch.Core.ApplicationService.Orders.Queries.GetOrders;

public class GetOrdersQueryHandler : QueryHandler<GetOrdersQuery, PagedData<OrderDto>>
{
    private readonly IOrderQueryRepository _orderQueryRepository;
    public GetOrdersQueryHandler(ZaminServices zaminServices, IOrderQueryRepository orderQueryRepository) : base(zaminServices)
    {
        _orderQueryRepository = orderQueryRepository;
    }

    public override async Task<QueryResult<PagedData<OrderDto>>> Handle(GetOrdersQuery query)
    {
        var res = await _orderQueryRepository.Select(query);
        return await ResultAsync(res);
    }
}