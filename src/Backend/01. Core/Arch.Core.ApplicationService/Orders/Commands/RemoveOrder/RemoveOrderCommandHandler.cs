using Arch.Core.Contracts.Orders.Commands;
using Arch.Core.Contracts.Orders.Commands.RemoveOrder;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Arch.Core.ApplicationService.Orders.Commands.RemoveOrder;

public class RemoveOrderCommandHandler : CommandHandler<RemoveOrderCommand>
{
    private readonly IOrderCommandRepository _orderCommandRepository;

    public RemoveOrderCommandHandler(ZaminServices zaminServices, IOrderCommandRepository orderCommandRepository) : base(zaminServices)
    {
        _orderCommandRepository = orderCommandRepository;
    }

    public override async Task<CommandResult> Handle(RemoveOrderCommand command)
    {
        var entity = await _orderCommandRepository.GetAsync(command.Id);

        entity.Remove();
        _orderCommandRepository.Delete(entity);
        await _orderCommandRepository.CommitAsync();

        return await OkAsync();
    }
}