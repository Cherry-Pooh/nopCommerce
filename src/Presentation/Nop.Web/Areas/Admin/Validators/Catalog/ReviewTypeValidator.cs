﻿using FluentValidation;
using Nop.Core.Domain.Catalog;
using Nop.Data;
using Nop.Services.Localization;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Framework.Validators;

namespace Nop.Web.Areas.Admin.Validators.Catalog
{
    /// <summary>
    /// Represent a review type validator
    /// </summary>
    public partial class ReviewTypeValidator : BaseNopValidator<ReviewTypeModel>
    {
        public ReviewTypeValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Settings.ReviewType.Fields.Name.Required").Result);
            RuleFor(x => x.Description).NotEmpty().WithMessage(localizationService.GetResource("Admin.Settings.ReviewType.Fields.Description.Required").Result);

            SetDatabaseValidationRules<ReviewType>(dataProvider);
        }
    }
}
