using Zamin.Core.RequestResponse.Queries;

namespace Arch.Core.Contracts.Orders.Queries.GetOrderById;

public class GetOrderByIdQuery : IQuery<OrderByIdDto>
{
    public Guid BusinessId { get; set; }
}