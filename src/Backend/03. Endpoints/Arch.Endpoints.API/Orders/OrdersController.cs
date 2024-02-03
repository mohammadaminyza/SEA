using Arch.Core.Contracts.Orders.Commands.AddOrderDetail;
using Arch.Core.Contracts.Orders.Commands.CreateOrder;
using Arch.Core.Contracts.Orders.Commands.RemoveOrder;
using Arch.Core.Contracts.Orders.Commands.UpdateOrderAddress;
using Arch.Core.Contracts.Orders.Queries.GetOrderById;
using Arch.Core.Contracts.Orders.Queries.GetOrders;
using Microsoft.AspNetCore.Mvc;
using Zamin.Core.RequestResponse.Queries;
using Zamin.EndPoints.Web.Controllers;

namespace Arch.Endpoints.API.Orders;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : BaseController
{
    [HttpGet("get")]
    public async Task<IActionResult> GetOrders([FromQuery] GetOrdersQuery query)
    {
        return await Query<GetOrdersQuery, PagedData<OrderDto>>(query);
    }

    [HttpGet("getById")]
    public async Task<IActionResult> GetOrderById([FromQuery] GetOrderByIdQuery query)
    {
        return await Query<GetOrderByIdQuery, OrderByIdDto>(query);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreteOrder([FromBody] CreateOrderCommand command)
    {
        return await Create(command);
    }

    [HttpPut("updateAddress")]
    public async Task<IActionResult> UpdateOrderAddress(UpdateOrderAddressCommand command)
    {
        return await Edit(command);
    }

    [HttpPut("addOrderDetail")]
    public async Task<IActionResult> AddOrderAddress([FromBody] AddOrderDetailCommand command)
    {
        return await Edit(command);
    }

    [HttpDelete("remove")]
    public async Task<IActionResult> UpdateOrderAddress([FromBody] RemoveOrderCommand command)
    {
        return await Delete(command);
    }
}