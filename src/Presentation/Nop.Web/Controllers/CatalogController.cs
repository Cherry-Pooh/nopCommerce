﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Vendors;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Services.Vendors;
using Nop.Web.Factories;
using Nop.Web.Framework;
using Nop.Web.Models.Catalog;

namespace Nop.Web.Controllers
{
    public partial class CatalogController : BasePublicController
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly IAclService _aclService;
        private readonly ICatalogModelFactory _catalogModelFactory;
        private readonly ICategoryService _categoryService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly ILocalizationService _localizationService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IPermissionService _permissionService;
        private readonly IProductModelFactory _productModelFactory;
        private readonly IProductService _productService;
        private readonly IProductTagService _productTagService;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IVendorService _vendorService;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly MediaSettings _mediaSettings;
        private readonly VendorSettings _vendorSettings;

        #endregion

        #region Ctor

        public CatalogController(CatalogSettings catalogSettings,
            IAclService aclService,
            ICatalogModelFactory catalogModelFactory,
            ICategoryService categoryService, 
            ICustomerActivityService customerActivityService,
            IGenericAttributeService genericAttributeService,
            ILocalizationService localizationService,
            IManufacturerService manufacturerService,
            IPermissionService permissionService, 
            IProductModelFactory productModelFactory,
            IProductService productService, 
            IProductTagService productTagService,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IVendorService vendorService,
            IWebHelper webHelper,
            IWorkContext workContext, 
            MediaSettings mediaSettings,
            VendorSettings vendorSettings)
        {
            _catalogSettings = catalogSettings;
            _aclService = aclService;
            _catalogModelFactory = catalogModelFactory;
            _categoryService = categoryService;
            _customerActivityService = customerActivityService;
            _genericAttributeService = genericAttributeService;
            _localizationService = localizationService;
            _manufacturerService = manufacturerService;
            _permissionService = permissionService;
            _productModelFactory = productModelFactory;
            _productService = productService;
            _productTagService = productTagService;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _vendorService = vendorService;
            _webHelper = webHelper;
            _workContext = workContext;
            _mediaSettings = mediaSettings;
            _vendorSettings = vendorSettings;
        }

        #endregion
        
        #region Categories
        
        public virtual async Task<IActionResult> Category(int categoryId, CatalogPagingFilteringModel command)
        {
            var category = await _categoryService.GetCategoryById(categoryId);
            if (category == null || category.Deleted)
                return InvokeHttp404();

            var notAvailable =
                //published?
                !category.Published ||
                //ACL (access control list) 
                !await _aclService.Authorize(category) ||
                //Store mapping
                !await _storeMappingService.Authorize(category);
            //Check whether the current user has a "Manage categories" permission (usually a store owner)
            //We should allows him (her) to use "Preview" functionality
            var hasAdminAccess = await _permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel) && await _permissionService.Authorize(StandardPermissionProvider.ManageCategories);
            if (notAvailable && !hasAdminAccess)
                return InvokeHttp404();

            //'Continue shopping' URL
            await _genericAttributeService.SaveAttribute(await _workContext.GetCurrentCustomer(), 
                NopCustomerDefaults.LastContinueShoppingPageAttribute, 
                _webHelper.GetThisPageUrl(false),
                (await _storeContext.GetCurrentStore()).Id);

            //display "edit" (manage) link
            if (await _permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel) && await _permissionService.Authorize(StandardPermissionProvider.ManageCategories))
                DisplayEditLink(Url.Action("Edit", "Category", new { id = category.Id, area = AreaNames.Admin }));

            //activity log
            await _customerActivityService.InsertActivity("PublicStore.ViewCategory",
                string.Format(await _localizationService.GetResource("ActivityLog.PublicStore.ViewCategory"), category.Name), category);

            //model
            var model = await _catalogModelFactory.PrepareCategoryModel(category, command);

            //template
            var templateViewPath = await _catalogModelFactory.PrepareCategoryTemplateViewPath(category.CategoryTemplateId);
            return View(templateViewPath, model);
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public virtual async Task<IActionResult> GetCatalogRoot()
        {
            var model = await _catalogModelFactory.PrepareRootCategories();

            return Json(model);
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public virtual async Task<IActionResult> GetCatalogSubCategories(int id)
        {
            var model = await _catalogModelFactory.PrepareSubCategories(id);

            return Json(model);
        }

        #endregion

        #region Manufacturers

        public virtual async Task<IActionResult> Manufacturer(int manufacturerId, CatalogPagingFilteringModel command)
        {
            var manufacturer = await _manufacturerService.GetManufacturerById(manufacturerId);
            if (manufacturer == null || manufacturer.Deleted)
                return InvokeHttp404();

            var notAvailable =
                //published?
                !manufacturer.Published ||
                //ACL (access control list) 
                !await _aclService.Authorize(manufacturer) ||
                //Store mapping
                !await _storeMappingService.Authorize(manufacturer);
            //Check whether the current user has a "Manage categories" permission (usually a store owner)
            //We should allows him (her) to use "Preview" functionality
            var hasAdminAccess = await _permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel) && await _permissionService.Authorize(StandardPermissionProvider.ManageManufacturers);
            if (notAvailable && !hasAdminAccess)
                return InvokeHttp404();

            //'Continue shopping' URL
            await _genericAttributeService.SaveAttribute(await _workContext.GetCurrentCustomer(), 
                NopCustomerDefaults.LastContinueShoppingPageAttribute, 
                _webHelper.GetThisPageUrl(false),
                (await _storeContext.GetCurrentStore()).Id);
            
            //display "edit" (manage) link
            if (await _permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel) && await _permissionService.Authorize(StandardPermissionProvider.ManageManufacturers))
                DisplayEditLink(Url.Action("Edit", "Manufacturer", new { id = manufacturer.Id, area = AreaNames.Admin }));

            //activity log
            await _customerActivityService.InsertActivity("PublicStore.ViewManufacturer",
                string.Format(await _localizationService.GetResource("ActivityLog.PublicStore.ViewManufacturer"), manufacturer.Name), manufacturer);

            //model
            var model = await _catalogModelFactory.PrepareManufacturerModel(manufacturer, command);
            
            //template
            var templateViewPath = await _catalogModelFactory.PrepareManufacturerTemplateViewPath(manufacturer.ManufacturerTemplateId);
            
            return View(templateViewPath, model);
        }

        public virtual async Task<IActionResult> ManufacturerAll()
        {
            var model = await _catalogModelFactory.PrepareManufacturerAllModels();
            
            return View(model);
        }
        
        #endregion

        #region Vendors

        public virtual async Task<IActionResult> Vendor(int vendorId, CatalogPagingFilteringModel command)
        {
            var vendor = await _vendorService.GetVendorById(vendorId);
            if (vendor == null || vendor.Deleted || !vendor.Active)
                return InvokeHttp404();

            //'Continue shopping' URL
            await _genericAttributeService.SaveAttribute(await _workContext.GetCurrentCustomer(),
                NopCustomerDefaults.LastContinueShoppingPageAttribute,
                _webHelper.GetThisPageUrl(false),
                (await _storeContext.GetCurrentStore()).Id);
            
            //display "edit" (manage) link
            if (await _permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel) && await _permissionService.Authorize(StandardPermissionProvider.ManageVendors))
                DisplayEditLink(Url.Action("Edit", "Vendor", new { id = vendor.Id, area = AreaNames.Admin }));

            //model
            var model = await _catalogModelFactory.PrepareVendorModel(vendor, command);

            return View(model);
        }

        public virtual async Task<IActionResult> VendorAll()
        {
            //we don't allow viewing of vendors if "vendors" block is hidden
            if (_vendorSettings.VendorsBlockItemsToDisplay == 0)
                return RedirectToRoute("Homepage");

            var model = await _catalogModelFactory.PrepareVendorAllModels();
            return View(model);
        }

        #endregion

        #region Product tags
        
        public virtual async Task<IActionResult> ProductsByTag(int productTagId, CatalogPagingFilteringModel command)
        {
            var productTag = await _productTagService.GetProductTagById(productTagId);
            if (productTag == null)
                return InvokeHttp404();

            var model = await _catalogModelFactory.PrepareProductsByTagModel(productTag, command);
            
            return View(model);
        }

        public virtual async Task<IActionResult> ProductTagsAll()
        {
            var model = await _catalogModelFactory.PrepareProductTagsAllModel();
            
            return View(model);
        }

        #endregion

        #region Searching

        public virtual async Task<IActionResult> Search(SearchModel model, CatalogPagingFilteringModel command)
        {
            //'Continue shopping' URL
            await _genericAttributeService.SaveAttribute(await _workContext.GetCurrentCustomer(),
                NopCustomerDefaults.LastContinueShoppingPageAttribute,
                _webHelper.GetThisPageUrl(true),
                (await _storeContext.GetCurrentStore()).Id);

            if (model == null)
                model = new SearchModel();

            model = await _catalogModelFactory.PrepareSearchModel(model, command);
           
            return View(model);
        }

        public virtual async Task<IActionResult> SearchTermAutoComplete(string term)
        {
            if (string.IsNullOrWhiteSpace(term) || term.Length < _catalogSettings.ProductSearchTermMinimumLength)
                return Content("");

            //products
            var productNumber = _catalogSettings.ProductSearchAutoCompleteNumberOfProducts > 0 ?
                _catalogSettings.ProductSearchAutoCompleteNumberOfProducts : 10;            

            var products = await _productService.SearchProducts(0,
                storeId: (await _storeContext.GetCurrentStore()).Id,
                keywords: term,
                languageId: (await _workContext.GetWorkingLanguage()).Id,
                visibleIndividuallyOnly: true,
                pageSize: productNumber);

            var showLinkToResultSearch = _catalogSettings.ShowLinkToAllResultInSearchAutoComplete && (products.TotalCount > productNumber);

            var models =  (await _productModelFactory.PrepareProductOverviewModels(products, false, _catalogSettings.ShowProductImagesInSearchAutoComplete, _mediaSettings.AutoCompleteSearchThumbPictureSize)).ToList();
            var result = (from p in models
                    select new
                    {
                        label = p.Name,
                        producturl = Url.RouteUrl("Product", new {SeName = p.SeName}),
                        productpictureurl = p.DefaultPictureModel.ImageUrl,
                        showlinktoresultsearch = showLinkToResultSearch
                    })
                .ToList();
            return Json(result);
        }
        
        #endregion
    }
}