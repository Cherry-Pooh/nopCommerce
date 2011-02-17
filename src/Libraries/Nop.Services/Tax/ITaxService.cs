using System.Collections.Generic;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Tax;

namespace Nop.Services.Tax
{
    /// <summary>
    /// Tax service
    /// </summary>
    public partial interface ITaxService
    {
        /// <summary>
        /// Load active tax provider
        /// </summary>
        /// <returns>Active tax provider</returns>
        ITaxProvider LoadActiveTaxProvider();

        /// <summary>
        /// Load tax provider by system name
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Found tax provider</returns>
        ITaxProvider LoadTaxProviderBySystemName(string systemName);

        /// <summary>
        /// Load all tax providers
        /// </summary>
        /// <returns>Tax providers</returns>
        IList<ITaxProvider> LoadAllTaxProviders();
        



        /// <summary>
        /// Gets tax rate
        /// </summary>
        /// <param name="productVariant">Product variant</param>
        /// <param name="customer">Customer</param>
        /// <returns>Tax rate</returns>
        decimal GetTaxRate(ProductVariant productVariant, Customer customer);

        /// <summary>
        /// Gets tax rate
        /// </summary>
        /// <param name="taxCategoryId">Tax category identifier</param>
        /// <param name="customer">Customer</param>
        /// <returns>Tax rate</returns>
        decimal GetTaxRate(int taxCategoryId, Customer customer);
        
        /// <summary>
        /// Gets tax rate
        /// </summary>
        /// <param name="productVariant">Product variant</param>
        /// <param name="taxCategoryId">Tax category identifier</param>
        /// <param name="customer">Customer</param>
        /// <returns>Tax rate</returns>
        decimal GetTaxRate(ProductVariant productVariant, int taxCategoryId, 
            Customer customer);
        



        /// <summary>
        /// Gets price
        /// </summary>
        /// <param name="productVariant">Product variant</param>
        /// <param name="price">Price</param>
        /// <param name="taxRate">Tax rate</param>
        /// <returns>Price</returns>
        decimal GetProductPrice(ProductVariant productVariant, decimal price,
            out decimal taxRate);

        /// <summary>
        /// Gets price
        /// </summary>
        /// <param name="productVariant">Product variant</param>
        /// <param name="price">Price</param>
        /// <param name="customer">Customer</param>
        /// <param name="taxRate">Tax rate</param>
        /// <returns>Price</returns>
        decimal GetProductPrice(ProductVariant productVariant, decimal price,
            Customer customer, out decimal taxRate);

        /// <summary>
        /// Gets price
        /// </summary>
        /// <param name="productVariant">Product variant</param>
        /// <param name="price">Price</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <param name="taxRate">Tax rate</param>
        /// <returns>Price</returns>
        decimal GetProductPrice(ProductVariant productVariant, decimal price,
            bool includingTax, Customer customer, out decimal taxRate);

        /// <summary>
        /// Gets price
        /// </summary>
        /// <param name="productVariant">Product variant</param>
        /// <param name="taxCategoryId">Tax category identifier</param>
        /// <param name="price">Price</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <param name="priceIncludesTax">A value indicating whether price already includes tax</param>
        /// <param name="taxRate">Tax rate</param>
        /// <returns>Price</returns>
        decimal GetProductPrice(ProductVariant productVariant, int taxCategoryId, decimal price,
            bool includingTax, Customer customer,
            bool priceIncludesTax, out decimal taxRate);




        /// <summary>
        /// Gets shipping price
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="customer">Customer</param>
        /// <returns>Price</returns>
        decimal GetShippingPrice(decimal price, Customer customer);

        /// <summary>
        /// Gets shipping price
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <returns>Price</returns>
        decimal GetShippingPrice(decimal price, bool includingTax, Customer customer);

        /// <summary>
        /// Gets shipping price
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <param name="taxRate">Tax rate</param>
        /// <returns>Price</returns>
        decimal GetShippingPrice(decimal price, bool includingTax, Customer customer, out decimal taxRate);





        /// <summary>
        /// Gets payment method additional handling fee
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="customer">Customer</param>
        /// <returns>Price</returns>
        decimal GetPaymentMethodAdditionalFee(decimal price, Customer customer);

        /// <summary>
        /// Gets payment method additional handling fee
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <returns>Price</returns>
        decimal GetPaymentMethodAdditionalFee(decimal price, bool includingTax, Customer customer);

        /// <summary>
        /// Gets payment method additional handling fee
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <param name="taxRate">Tax rate</param>
        /// <returns>Price</returns>
        decimal GetPaymentMethodAdditionalFee(decimal price, bool includingTax, Customer customer, out decimal taxRate);







        /// <summary>
        /// Gets checkout attribute value price
        /// </summary>
        /// <param name="cav">Checkout attribute value</param>
        /// <returns>Price</returns>
        decimal GetCheckoutAttributePrice(CheckoutAttributeValue cav);

        /// <summary>
        /// Gets checkout attribute value price
        /// </summary>
        /// <param name="cav">Checkout attribute value</param>
        /// <param name="customer">Customer</param>
        /// <returns>Price</returns>
        decimal GetCheckoutAttributePrice(CheckoutAttributeValue cav, Customer customer);

        /// <summary>
        /// Gets checkout attribute value price
        /// </summary>
        /// <param name="cav">Checkout attribute value</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <returns>Price</returns>
        decimal GetCheckoutAttributePrice(CheckoutAttributeValue cav,
            bool includingTax, Customer customer);

        /// <summary>
        /// Gets checkout attribute value price
        /// </summary>
        /// <param name="cav">Checkout attribute value</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <param name="taxRate">Tax rate</param>
        /// <returns>Price</returns>
        decimal GetCheckoutAttributePrice(CheckoutAttributeValue cav,
            bool includingTax, Customer customer, out decimal taxRate);





        /// <summary>
        /// Gets VAT Number status
        /// </summary>
        /// <param name="country">Country</param>
        /// <param name="vatNumber">VAT number</param>
        /// <returns>VAT Number status</returns>
        VatNumberStatus GetVatNumberStatus(Country country,
            string vatNumber);
        
        /// <summary>
        /// Gets VAT Number status
        /// </summary>
        /// <param name="country">Country</param>
        /// <param name="vatNumber">VAT number</param>
        /// <param name="name">Name (if received)</param>
        /// <param name="address">Address (if received)</param>
        /// <returns>VAT Number status</returns>
        VatNumberStatus GetVatNumberStatus(Country country,
            string vatNumber, out string name, out string address);
    }
}
