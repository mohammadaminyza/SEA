using Arch.Core.Contracts.Orders.Commands;
using Arch.Core.Contracts.Orders.Commands.CreateOrder;
using Arch.Core.Domain.Orders.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Arch.Core.ApplicationService.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : CommandHandler<CreateOrderCommand>
{
    private readonly IOrderCommandRepository _orderCommandRepository;

    public CreateOrderCommandHandler(ZaminServices zaminServices, IOrderCommandRepository orderCommandRepository) : base(zaminServices)
    {
        _orderCommandRepository = orderCommandRepository;
    }

    public override async Task<CommandResult> Handle(CreateOrderCommand command)
    {
        var entity = new Order(Guid.NewGuid(), command.UserId, (command.Street, command.Plaque), command.OrderDetail.ProductId, command.OrderDetail.Count);

        await _orderCommandRepository.InsertAsync(entity);
        await _orderCommandRepository.CommitAsync();

        return await OkAsync();
    }
}