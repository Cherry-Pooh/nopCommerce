﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.NivoSlider
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class NivoSliderPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ILocalizationService _localizationService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly INopFileProvider _fileProvider;

        public NivoSliderPlugin(ILocalizationService localizationService,
            IPictureService pictureService,
            ISettingService settingService,
            IWebHelper webHelper,
            INopFileProvider fileProvider)
        {
            _localizationService = localizationService;
            _pictureService = pictureService;
            _settingService = settingService;
            _webHelper = webHelper;
            _fileProvider = fileProvider;
        }

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.HomepageTop };
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation().Result + "Admin/WidgetsNivoSlider/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsNivoSlider";
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override async Task Install()
        {
            //pictures
            var sampleImagesPath = _fileProvider.MapPath("~/Plugins/Widgets.NivoSlider/Content/nivoslider/sample-images/");

            //settings
            var settings = new NivoSliderSettings
            {
                Picture1Id = (await _pictureService.InsertPicture(await _fileProvider.ReadAllBytes(_fileProvider.Combine(sampleImagesPath, "banner1.jpg")), MimeTypes.ImagePJpeg, "banner_1")).Id,
                Text1 = "",
                Link1 = await _webHelper.GetStoreLocation(false),
                Picture2Id = (await _pictureService.InsertPicture(await _fileProvider.ReadAllBytes(_fileProvider.Combine(sampleImagesPath, "banner2.jpg")), MimeTypes.ImagePJpeg, "banner_2")).Id,
                Text2 = "",
                Link2 = await _webHelper.GetStoreLocation(false)
                //Picture3Id = _pictureService.InsertPicture(File.ReadAllBytes(_fileProvider.Combine(sampleImagesPath,"banner3.jpg")), MimeTypes.ImagePJpeg, "banner_3").Id,
                //Text3 = "",
                //Link3 = _webHelper.GetStoreLocation(false),
            };
            await _settingService.SaveSetting(settings);

            await _localizationService.AddLocaleResource(new Dictionary<string, string>
            {
                ["Plugins.Widgets.NivoSlider.Picture1"] = "Picture 1",
                ["Plugins.Widgets.NivoSlider.Picture2"] = "Picture 2",
                ["Plugins.Widgets.NivoSlider.Picture3"] = "Picture 3",
                ["Plugins.Widgets.NivoSlider.Picture4"] = "Picture 4",
                ["Plugins.Widgets.NivoSlider.Picture5"] = "Picture 5",
                ["Plugins.Widgets.NivoSlider.Picture"] = "Picture",
                ["Plugins.Widgets.NivoSlider.Picture.Hint"] = "Upload picture.",
                ["Plugins.Widgets.NivoSlider.Text"] = "Comment",
                ["Plugins.Widgets.NivoSlider.Text.Hint"] = "Enter comment for picture. Leave empty if you don't want to display any text.",
                ["Plugins.Widgets.NivoSlider.Link"] = "URL",
                ["Plugins.Widgets.NivoSlider.Link.Hint"] = "Enter URL. Leave empty if you don't want this picture to be clickable.",
                ["Plugins.Widgets.NivoSlider.AltText"] = "Image alternate text",
                ["Plugins.Widgets.NivoSlider.AltText.Hint"] = "Enter alternate text that will be added to image."
            });

            await base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override async Task Uninstall()
        {
            //settings
            await _settingService.DeleteSetting<NivoSliderSettings>();

            //locales
            await _localizationService.DeleteLocaleResources("Plugins.Widgets.NivoSlider");

            await base.Uninstall();
        }

        /// <summary>
        /// Gets a value indicating whether to hide this plugin on the widget list page in the admin area
        /// </summary>
        public bool HideInWidgetList => false;
    }
}