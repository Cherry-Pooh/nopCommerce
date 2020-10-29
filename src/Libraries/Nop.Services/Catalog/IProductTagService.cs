﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// Product tag service interface
    /// </summary>
    public partial interface IProductTagService
    {
        /// <summary>
        /// Delete a product tag
        /// </summary>
        /// <param name="productTag">Product tag</param>
        Task DeleteProductTagAsync(ProductTag productTag);

        /// <summary>
        /// Delete product tags
        /// </summary>
        /// <param name="productTags">Product tags</param>
        Task DeleteProductTagsAsync(IList<ProductTag> productTags);

        /// <summary>
        /// Gets product tags
        /// </summary>
        /// <param name="productTagIds">Product tags identifiers</param>
        /// <returns>Product tags</returns>
        Task<IList<ProductTag>> GetProductTagsByIdsAsync(int[] productTagIds);

        //TODO: may be deleted from interface
        /// <summary>
        /// Indicates whether a product tag exists
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="productTagId">Product tag identifier</param>
        /// <returns>Result</returns>
        Task<bool> ProductTagExistsAsync(Product product, int productTagId);

        /// <summary>
        /// Gets all product tags
        /// </summary>
        /// <param name="tagName">Tag name</param>
        /// <returns>Product tags</returns>
        Task<IList<ProductTag>> GetAllProductTagsAsync(string tagName = null);

        /// <summary>
        /// Gets all product tags by product identifier
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>Product tags</returns>
        Task<IList<ProductTag>> GetAllProductTagsByProductIdAsync(int productId);

        /// <summary>
        /// Gets product tag
        /// </summary>
        /// <param name="productTagId">Product tag identifier</param>
        /// <returns>Product tag</returns>
        Task<ProductTag> GetProductTagByIdAsync(int productTagId);

        //TODO: may be deleted from interface
        /// <summary>
        /// Gets product tag by name
        /// </summary>
        /// <param name="name">Product tag name</param>
        /// <returns>Product tag</returns>
        Task<ProductTag> GetProductTagByNameAsync(string name);

        /// <summary>
        /// Inserts a product-product tag mapping
        /// </summary>
        /// <param name="tagMapping">Product-product tag mapping</param>
        Task InsertProductProductTagMappingAsync(ProductProductTagMapping tagMapping);

        /// <summary>
        /// Inserts a product tag
        /// </summary>
        /// <param name="productTag">Product tag</param>
        Task InsertProductTagAsync(ProductTag productTag);

        /// <summary>
        /// Updates the product tag
        /// </summary>
        /// <param name="productTag">Product tag</param>
        Task UpdateProductTagAsync(ProductTag productTag);

        /// <summary>
        /// Get number of products
        /// </summary>
        /// <param name="productTagId">Product tag identifier</param>
        /// <param name="storeId">Store identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Number of products</returns>
        Task<int> GetProductCountAsync(int productTagId, int storeId, bool showHidden = false);

        /// <summary>
        /// Update product tags
        /// </summary>
        /// <param name="product">Product for update</param>
        /// <param name="productTags">Product tags</param>
        Task UpdateProductTagsAsync(Product product, string[] productTags);
    }
}
