﻿using Arch.Core.Contracts.Orders.Commands.CreateOrder;
using Arch.Core.Domain.Common.Resources;
using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace Arch.Core.ApplicationService.Orders.Commands.CreateOrder;

public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator(ITranslator translator)
    {
        RuleFor(o => o.Street)
            .NotEmpty().WithMessage(translator[ArchValidationError.VALIDATION_ERROR_REQUIRED, nameof(CreateOrderCommand.Street)]);

        RuleFor(o => o.Plaque)
            .NotEmpty().WithMessage(translator[ArchValidationError.VALIDATION_ERROR_REQUIRED, nameof(CreateOrderCommand.Plaque)]);

        RuleFor(o => o.UserId)
            .NotEmpty().WithMessage(translator[ArchValidationError.VALIDATION_ERROR_REQUIRED, nameof(CreateOrderCommand.UserId)]);

        RuleFor(o => o.OrderDetail.ProductId)
            .NotEmpty().WithMessage(translator[ArchValidationError.VALIDATION_ERROR_REQUIRED, nameof(CreateOrderCommand.OrderDetail.ProductId)]);

        RuleFor(o => o.OrderDetail.Count)
            .NotEmpty().WithMessage(translator[ArchValidationError.VALIDATION_ERROR_REQUIRED, nameof(CreateOrderCommand.OrderDetail.Count)]);
    }
}