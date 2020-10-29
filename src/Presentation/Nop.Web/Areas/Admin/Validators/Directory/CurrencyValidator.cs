﻿using System.Globalization;
using FluentValidation;
using Nop.Core.Domain.Directory;
using Nop.Data;
using Nop.Services.Localization;
using Nop.Web.Areas.Admin.Models.Directory;
using Nop.Web.Framework.Validators;

namespace Nop.Web.Areas.Admin.Validators.Directory
{
    public partial class CurrencyValidator : BaseNopValidator<CurrencyModel>
    {
        public CurrencyValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(localizationService.GetResourceAsync("Admin.Configuration.Currencies.Fields.Name.Required").Result)
                .Length(1, 50).WithMessage(localizationService.GetResourceAsync("Admin.Configuration.Currencies.Fields.Name.Range").Result);
            RuleFor(x => x.CurrencyCode)
                .NotEmpty().WithMessage(localizationService.GetResourceAsync("Admin.Configuration.Currencies.Fields.CurrencyCode.Required").Result)
                .Length(1, 5).WithMessage(localizationService.GetResourceAsync("Admin.Configuration.Currencies.Fields.CurrencyCode.Range").Result);
            RuleFor(x => x.Rate)
                .GreaterThan(0).WithMessage(localizationService.GetResourceAsync("Admin.Configuration.Currencies.Fields.Rate.Range").Result);
            RuleFor(x => x.CustomFormatting)
                .Length(0, 50).WithMessage(localizationService.GetResourceAsync("Admin.Configuration.Currencies.Fields.CustomFormatting.Validation").Result);
            RuleFor(x => x.DisplayLocale)
                .Must(x =>
                {
                    try
                    {
                        if (string.IsNullOrEmpty(x))
                            return true;
                        //let's try to create a CultureInfo object
                        //if "DisplayLocale" is wrong, then exception will be thrown
                        var unused = new CultureInfo(x);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                })
                .WithMessage(localizationService.GetResourceAsync("Admin.Configuration.Currencies.Fields.DisplayLocale.Validation").Result);

            SetDatabaseValidationRules<Currency>(dataProvider);
        }
    }
}