//------------------------------------------------------------------------------
// The contents of this file are subject to the nopCommerce Public License Version 1.0 ("License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at  http://www.nopCommerce.com/License.aspx. 
// 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. 
// See the License for the specific language governing rights and limitations under the License.
// 
// The Original Code is nopCommerce.
// The Initial Developer of the Original Code is NopSolutions.
// All Rights Reserved.
// 
// Contributor(s): _______. 
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Nop.Core.Domain;

namespace Nop.Services
{
    /// <summary>
    /// Product service
    /// </summary>
    public partial interface IProductService
    {
        #region Products

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="product">Product</param>
        void DeleteProduct(Product product);

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>Product collection</returns>
        List<Product> GetAllProducts();

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Product collection</returns>
        List<Product> GetAllProducts(bool showHidden);

        /// <summary>
        /// Gets all products displayed on the home page
        /// </summary>
        /// <returns>Product collection</returns>
        List<Product> GetAllProductsDisplayedOnHomePage();
        
        /// <summary>
        /// Gets product
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>Product</returns>
        Product GetProductById(int productId);
        
        /// <summary>
        /// Inserts a product
        /// </summary>
        /// <param name="product">Product</param>
        void InsertProduct(Product product);

        /// <summary>
        /// Updates the product
        /// </summary>
        /// <param name="product">Product</param>
        void UpdateProduct(Product product);

        /// <summary>
        /// Gets localized product by id
        /// </summary>
        /// <param name="localizedProductId">Localized product identifier</param>
        /// <returns>Product content</returns>
        LocalizedProduct GetLocalizedProductById(int localizedProductId);

        /// <summary>
        /// Gets localized product by product id
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>Product content</returns>
        List<LocalizedProduct> GetLocalizedProductByProductId(int productId);

        /// <summary>
        /// Gets localized product by product id and language id
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Product content</returns>
        LocalizedProduct GetLocalizedProductByProductIdAndLanguageId(int productId, int languageId);

        /// <summary>
        /// Inserts a localized product
        /// </summary>
        /// <param name="localizedProduct">Product content</param>
        void InsertLocalizedProduct(LocalizedProduct localizedProduct);

        /// <summary>
        /// Update a localized product
        /// </summary>
        /// <param name="localizedProduct">Product content</param>
        void UpdateLocalizedProduct(LocalizedProduct localizedProduct);

        #endregion

        #region Product variants

        /// <summary>
        /// Get low stock product variants
        /// </summary>
        /// <returns>Result</returns>
        List<ProductVariant> GetLowStockProductVariants();

        /// <summary>
        /// Gets a product variant
        /// </summary>
        /// <param name="productVariantId">Product variant identifier</param>
        /// <returns>Product variant</returns>
        ProductVariant GetProductVariantById(int productVariantId);

        /// <summary>
        /// Gets a product variant by SKU
        /// </summary>
        /// <param name="sku">SKU</param>
        /// <returns>Product variant</returns>
        ProductVariant GetProductVariantBySku(string sku);
        
        /// <summary>
        /// Inserts a product variant
        /// </summary>
        /// <param name="productVariant">The product variant</param>
        void InsertProductVariant(ProductVariant productVariant);

        /// <summary>
        /// Updates the product variant
        /// </summary>
        /// <param name="productVariant">The product variant</param>
        void UpdateProductVariant(ProductVariant productVariant);

        /// <summary>
        /// Gets product variants by product identifier
        /// </summary>
        /// <param name="productId">The product identifier</param>
        /// <returns>Product variant collection</returns>
        List<ProductVariant> GetProductVariantsByProductId(int productId);
        
        /// <summary>
        /// Gets product variants by product identifier
        /// </summary>
        /// <param name="productId">The product identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Product variant collection</returns>
        List<ProductVariant> GetProductVariantsByProductId(int productId, bool showHidden);

        /// <summary>
        /// Gets localized product variant by id
        /// </summary>
        /// <param name="localizedProductVariantId">Localized product variant identifier</param>
        /// <returns>Product variant content</returns>
        LocalizedProductVariant GetLocalizedProductVariantById(int localizedProductVariantId);

        /// <summary>
        /// Gets localized product variant by product variant id
        /// </summary>
        /// <param name="productVariantId">Product variant identifier</param>
        /// <returns>Product variant content</returns>
        List<LocalizedProductVariant> GetLocalizedProductVariantByProductVariantId(int productVariantId);
        
        /// <summary>
        /// Gets localized product variant by product variant id and language id
        /// </summary>
        /// <param name="productVariantId">Product variant identifier</param>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Product variant content</returns>
        LocalizedProductVariant GetLocalizedProductVariantByProductVariantIdAndLanguageId(int productVariantId, int languageId);

        /// <summary>
        /// Inserts a localized product variant
        /// </summary>
        /// <param name="localizedProductVariant">Localized product variant</param>
        void InsertLocalizedProductVariant(LocalizedProductVariant localizedProductVariant);

        /// <summary>
        /// Update a localized product variant
        /// </summary>
        /// <param name="localizedProductVariant">Localized product variant</param>
        void UpdateLocalizedProductVariant(LocalizedProductVariant localizedProductVariant);

        /// <summary>
        /// Delete a product variant
        /// </summary>
        /// <param name="productVariant">Product variant</param>
        void DeleteProductVariant(ProductVariant productVariant);

        #endregion

        #region Related products

        /// <summary>
        /// Deletes a related product
        /// </summary>
        /// <param name="relatedProduct">Related product</param>
        void DeleteRelatedProduct(RelatedProduct relatedProduct);

        /// <summary>
        /// Gets a related product collection by product identifier
        /// </summary>
        /// <param name="productId1">The first product identifier</param>
        /// <returns>Related product collection</returns>
        List<RelatedProduct> GetRelatedProductsByProductId1(int productId1);

        /// <summary>
        /// Gets a related product
        /// </summary>
        /// <param name="relatedProductId">Related product identifer</param>
        /// <returns>Related product</returns>
        RelatedProduct GetRelatedProductById(int relatedProductId);

        /// <summary>
        /// Inserts a related product
        /// </summary>
        /// <param name="relatedProduct">Related product</param>
        void InsertRelatedProduct(RelatedProduct relatedProduct);

        /// <summary>
        /// Updates a related product
        /// </summary>
        /// <param name="relatedProduct">Related product</param>
        void UpdateRelatedProduct(RelatedProduct relatedProduct);

        #endregion

        #region Cross-sell products

        /// <summary>
        /// Deletes a cross-sell product
        /// </summary>
        /// <param name="crossSellProduct">Cross-sell</param>
        void DeleteCrossSellProduct(CrossSellProduct crossSellProduct);

        /// <summary>
        /// Gets a cross-sell product collection by product identifier
        /// </summary>
        /// <param name="productId1">The first product identifier</param>
        /// <returns>Cross-sell product collection</returns>
        List<CrossSellProduct> GetCrossSellProductsByProductId1(int productId1);

        /// <summary>
        /// Gets a cross-sell product
        /// </summary>
        /// <param name="crossSellProductId">Cross-sell product identifer</param>
        /// <returns>Cross-sell product</returns>
        CrossSellProduct GetCrossSellProductById(int crossSellProductId);

        /// <summary>
        /// Inserts a cross-sell product
        /// </summary>
        /// <param name="crossSellProduct">Cross-sell product</param>
        void InsertCrossSellProduct(CrossSellProduct crossSellProduct);

        /// <summary>
        /// Updates a cross-sell product
        /// </summary>
        /// <param name="crossSellProduct">Cross-sell product</param>
        void UpdateCrossSellProduct(CrossSellProduct crossSellProduct);

        #endregion

    }
}
