﻿using System.Collections.Generic;
using FluentValidation.Attributes;
using Nop.Web.Areas.Admin.Validators.Shipping;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Shipping
{
    [Validator(typeof(ProductAvailabilityRangeValidator))]
    public partial class ProductAvailabilityRangeModel : BaseNopEntityModel, ILocalizedModel<ProductAvailabilityRangeLocalizedModel>
    {
        public ProductAvailabilityRangeModel()
        {
            Locales = new List<ProductAvailabilityRangeLocalizedModel>();
        }

        [NopResourceDisplayName("Admin.Configuration.Shipping.ProductAvailabilityRanges.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.ProductAvailabilityRanges.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<ProductAvailabilityRangeLocalizedModel> Locales { get; set; }
    }

    public partial class ProductAvailabilityRangeLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.ProductAvailabilityRanges.Fields.Name")]
        public string Name { get; set; }
    }
}