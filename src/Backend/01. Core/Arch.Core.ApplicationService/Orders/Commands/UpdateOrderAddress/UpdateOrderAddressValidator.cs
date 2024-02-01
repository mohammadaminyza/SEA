using Arch.Core.Contracts.Orders.Commands.UpdateOrderAddress;
using Arch.Core.Domain.Common.Resources;
using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace Arch.Core.ApplicationService.Orders.Commands.UpdateOrderAddress;

public class UpdateOrderAddressValidator : AbstractValidator<UpdateOrderAddressCommand>
{
    public UpdateOrderAddressValidator(ITranslator translator)
    {
        RuleFor(o => o.Street)
            .NotEmpty().WithMessage(translator[ArchValidationError.VALIDATION_ERROR_REQUIRED, nameof(UpdateOrderAddressCommand.Street)]);

        RuleFor(o => o.Plaque)
            .NotEmpty().WithMessage(translator[ArchValidationError.VALIDATION_ERROR_REQUIRED, nameof(UpdateOrderAddressCommand.Plaque)]);
    }
}