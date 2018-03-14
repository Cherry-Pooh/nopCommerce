﻿using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Services.Catalog;
using Nop.Services.Customers;
using Nop.Web.Areas.Admin.Extensions;
using Nop.Web.Areas.Admin.Models.Customers;
using Nop.Web.Framework.Extensions;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the customer role model factory implementation
    /// </summary>
    public partial class CustomerRoleModelFactory : ICustomerRoleModelFactory
    {
        #region Fields

        private readonly IBaseAdminModelFactory _baseAdminModelFactory;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public CustomerRoleModelFactory(IBaseAdminModelFactory baseAdminModelFactory,
            ICustomerService customerService,
            IProductService productService,
            IWorkContext workContext)
        {
            this._baseAdminModelFactory = baseAdminModelFactory;
            this._customerService = customerService;
            this._productService = productService;
            this._workContext = workContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare customer role search model
        /// </summary>
        /// <param name="model">Customer role search model</param>
        /// <returns>Customer role search model</returns>
        public virtual CustomerRoleSearchModel PrepareCustomerRoleSearchModel(CustomerRoleSearchModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return model;
        }

        /// <summary>
        /// Prepare paged customer role list model
        /// </summary>
        /// <param name="searchModel">Customer role search model</param>
        /// <returns>Customer role list model</returns>
        public virtual CustomerRoleListModel PrepareCustomerRoleListModel(CustomerRoleSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get customer roles
            var customerRoles = _customerService.GetAllCustomerRoles(true);

            //prepare grid model
            var model = new CustomerRoleListModel
            {
                Data = customerRoles.PaginationByRequestModel(searchModel).Select(role =>
                {
                    //fill in model values from the entity
                    var customerRoleModel = role.ToModel();

                    //fill in additional values (not existing in the entity)
                    customerRoleModel.PurchasedWithProductName = _productService.GetProductById(role.PurchasedWithProductId)?.Name;

                    return customerRoleModel;
                }),
                Total = customerRoles.Count
            };

            return model;
        }

        /// <summary>
        /// Prepare customer role model
        /// </summary>
        /// <param name="model">Customer role model</param>
        /// <param name="customerRole">Customer role</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>Customer role model</returns>
        public virtual CustomerRoleModel PrepareCustomerRoleModel(CustomerRoleModel model, CustomerRole customerRole, bool excludeProperties = false)
        {
            if (customerRole != null)
            {
                //fill in model values from the entity
                model = model ?? customerRole.ToModel();
                model.PurchasedWithProductName = _productService.GetProductById(customerRole.PurchasedWithProductId)?.Name;
            }

            //set default values for the new model
            if (customerRole == null)
                model.Active = true;

            //prepare available tax display types
            _baseAdminModelFactory.PrepareTaxDisplayTypes(model.TaxDisplayTypeValues, false);

            return model;
        }

        /// <summary>
        /// Prepare customer role product search model
        /// </summary>
        /// <param name="model">Customer role product search model</param>
        /// <returns>Customer role product search model</returns>
        public virtual CustomerRoleProductSearchModel PrepareCustomerRoleProductSearchModel(CustomerRoleProductSearchModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            //a vendor should have access only to his products
            model.IsLoggedInAsVendor = _workContext.CurrentVendor != null;

            //prepare available categories
            _baseAdminModelFactory.PrepareCategories(model.AvailableCategories);

            //prepare available manufacturers
            _baseAdminModelFactory.PrepareManufacturers(model.AvailableManufacturers);

            //prepare available stores
            _baseAdminModelFactory.PrepareStores(model.AvailableStores);

            //prepare available vendors
            _baseAdminModelFactory.PrepareVendors(model.AvailableVendors);

            //prepare available product types
            _baseAdminModelFactory.PrepareProductTypes(model.AvailableProductTypes);

            return model;
        }

        /// <summary>
        /// Prepare paged customer role product list model
        /// </summary>
        /// <param name="searchModel">Customer role product search model</param>
        /// <returns>Customer role product list model</returns>
        public virtual CustomerRoleProductListModel PrepareCustomerRoleProductListModel(CustomerRoleProductSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //a vendor should have access only to his products
            if (_workContext.CurrentVendor != null)
                searchModel.SearchVendorId = _workContext.CurrentVendor.Id;

            //get products
            var products = _productService.SearchProducts(showHidden: true,
                categoryIds: new List<int> { searchModel.SearchCategoryId },
                manufacturerId: searchModel.SearchManufacturerId,
                storeId: searchModel.SearchStoreId,
                vendorId: searchModel.SearchVendorId,
                productType: searchModel.SearchProductTypeId > 0 ? (ProductType?)searchModel.SearchProductTypeId : null,
                keywords: searchModel.SearchProductName,
                pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);

            //prepare grid model
            var model = new CustomerRoleProductListModel
            {
                //fill in model values from the entity
                Data = products.Select(product => product.ToModel()),
                Total = products.TotalCount
            };

            return model;
        }

        #endregion
    }
}