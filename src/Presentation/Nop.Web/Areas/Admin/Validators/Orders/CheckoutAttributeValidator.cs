﻿using FluentValidation;
using Nop.Core.Domain.Orders;
using Nop.Data.Mapping;
using Nop.Services.Localization;
using Nop.Web.Areas.Admin.Models.Orders;
using Nop.Web.Framework.Validators;

namespace Nop.Web.Areas.Admin.Validators.Orders;

public partial class CheckoutAttributeValidator : BaseNopValidator<CheckoutAttributeModel>
{
    public CheckoutAttributeValidator(ILocalizationService localizationService, IMappingEntityAccessor mappingEntityAccessor)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Catalog.Attributes.CheckoutAttributes.Fields.Name.Required"));

        SetDatabaseValidationRules<CheckoutAttribute>(mappingEntityAccessor);
    }
}