﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Web.Components
{
    public class SocialButtonsViewComponent : NopViewComponent
    {
        private readonly ICommonModelFactory _commonModelFactory;

        public SocialButtonsViewComponent(ICommonModelFactory commonModelFactory)
        {
            _commonModelFactory = commonModelFactory;
        }

        public async Task<IViewComponentResult> Invoke()
        {
            var model = await _commonModelFactory.PrepareSocialModel();
            return View(model);
        }
    }
}
