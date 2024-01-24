using Arch.Core.Contracts.Orders.Commands.UpdateOrderAddress;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Arch.Core.ApplicationService.Orders.Commands.UpdateOrderAddress;

public class UpdateOrderAddressCommandHandler : CommandHandler<UpdateOrderAddressCommand>
{
    public UpdateOrderAddressCommandHandler(ZaminServices zaminServices) : base(zaminServices)
    {
    }

    public override async Task<CommandResult> Handle(UpdateOrderAddressCommand command)
    {
        return await OkAsync();
    }
}