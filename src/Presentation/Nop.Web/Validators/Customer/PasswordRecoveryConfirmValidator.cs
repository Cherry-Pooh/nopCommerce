﻿using FluentValidation;
using Nop.Core.Domain.Customers;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Nop.Web.Models.Customer;

namespace Nop.Web.Validators.Customer
{
    public partial class PasswordRecoveryConfirmValidator : BaseNopValidator<PasswordRecoveryConfirmModel>
    {
        public PasswordRecoveryConfirmValidator(ILocalizationService localizationService, CustomerSettings customerSettings)
        {
            RuleFor(x => x.NewPassword).IsPassword(localizationService, customerSettings);            
            RuleFor(x => x.ConfirmNewPassword).NotEmpty().WithMessage(localizationService.GetResourceAsync("Account.PasswordRecovery.ConfirmNewPassword.Required").Result);
            RuleFor(x => x.ConfirmNewPassword).Equal(x => x.NewPassword).WithMessage(localizationService.GetResourceAsync("Account.PasswordRecovery.NewPassword.EnteredPasswordsDoNotMatch").Result);
        }
    }
}