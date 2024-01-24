using Arch.Core.Contracts.Orders.Commands.RemoveOrder;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Arch.Core.ApplicationService.Orders.Commands.RemoveOrder;

public class RemoveOrderCommandHandler : CommandHandler<RemoveOrderCommand>
{
    public RemoveOrderCommandHandler(ZaminServices zaminServices) : base(zaminServices)
    {
    }

    public override async Task<CommandResult> Handle(RemoveOrderCommand command)
    {
        return await OkAsync();
    }
}