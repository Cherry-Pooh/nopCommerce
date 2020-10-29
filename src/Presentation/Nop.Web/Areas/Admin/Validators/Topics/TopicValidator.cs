﻿using FluentValidation;
using Nop.Core.Domain.Topics;
using Nop.Data;
using Nop.Services.Localization;
using Nop.Services.Seo;
using Nop.Web.Areas.Admin.Models.Topics;
using Nop.Web.Framework.Validators;

namespace Nop.Web.Areas.Admin.Validators.Topics
{
    public partial class TopicValidator : BaseNopValidator<TopicModel>
    {
        public TopicValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.SeName)
                .Length(0, NopSeoDefaults.ForumTopicLength)
                .WithMessage(string.Format(localizationService.GetResourceAsync("Admin.SEO.SeName.MaxLengthValidation").Result, NopSeoDefaults.ForumTopicLength));

            RuleFor(x => x.Password)
                .NotEmpty()
                .When(x => x.IsPasswordProtected)
                .WithMessage(localizationService.GetResourceAsync("Validation.Password.IsNotEmpty").Result);

            SetDatabaseValidationRules<Topic>(dataProvider);
        }
    }
}
