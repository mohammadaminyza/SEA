using Arch.Core.Contracts.Orders.Commands;
using Arch.Core.Contracts.Orders.Commands.UpdateOrderAddress;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Arch.Core.ApplicationService.Orders.Commands.UpdateOrderAddress;

public class UpdateOrderAddressCommandHandler : CommandHandler<UpdateOrderAddressCommand>
{
    private readonly IOrderCommandRepository _orderCommandRepository;

    public UpdateOrderAddressCommandHandler(ZaminServices zaminServices, IOrderCommandRepository orderCommandRepository) : base(zaminServices)
    {
        _orderCommandRepository = orderCommandRepository;
    }

    public override async Task<CommandResult> Handle(UpdateOrderAddressCommand command)
    {
        var entity = await _orderCommandRepository.GetAsync(command.OrderId);

        entity.UpdateAddress((command.Street, command.Plaque));
        await _orderCommandRepository.CommitAsync();

        return await OkAsync();
    }
}