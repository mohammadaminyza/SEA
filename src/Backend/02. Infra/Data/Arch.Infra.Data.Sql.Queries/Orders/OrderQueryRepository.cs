using Arch.Core.Contracts.Orders.Queries;
using Arch.Core.Contracts.Orders.Queries.GetOrders;
using Arch.Infra.Data.Sql.Queries.Common;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Infra.Data.Sql.Queries;
using Zamin.Utilities.Extensions;

namespace Arch.Infra.Data.Sql.Queries.Orders;

public class OrderQueryRepository : BaseQueryRepository<ArchQueryDbContext>, IOrderQueryRepository
{
    public OrderQueryRepository(ArchQueryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<PagedData<OrderDto>> Select(GetOrdersQuery dto)
    {
        var query = _dbContext.Orders.AsQueryable();

        #region Filter

        query = query.WhereIf(dto.UserId != null, o => o.UserId == dto.UserId);
        // others

        #endregion

        #region Result

        var result = await query.ToPagedData(dto, c => new OrderDto()
        {

        });

        #endregion

        return result;
    }
}