using Arch.Core.Contracts.Orders.Commands;
using Arch.Core.Contracts.Orders.Commands.AddOrderDetail;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Arch.Core.ApplicationService.Orders.Commands.AddOrderDetail;

public class AddOrderDetailCommandHandler : CommandHandler<AddOrderDetailCommand>
{
    private readonly IOrderCommandRepository _orderCommandRepository;

    public AddOrderDetailCommandHandler(ZaminServices zaminServices, IOrderCommandRepository orderCommandRepository) : base(zaminServices)
    {
        _orderCommandRepository = orderCommandRepository;
    }

    public override async Task<CommandResult> Handle(AddOrderDetailCommand command)
    {
        var order = await _orderCommandRepository.GetAsync(command.OrderId);
        order.AddOrderDetail(command.OrderId, command.ProductId, command.Count);
        await _orderCommandRepository.CommitAsync();

        return await OkAsync();
    }
}