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

using System.Collections.Generic;
using Nop.Core.Domain;

namespace Nop.Services
{
    /// <summary>
    /// Category service interface
    /// </summary>
    public partial interface ICategoryService
    {
        /// <summary>
        /// Marks category as deleted
        /// </summary>
        /// <param name="category">Category</param>
        void DeleteCategory(Category category);

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns>Categories</returns>
        List<Category> GetAllCategories();
        
        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Categories</returns>
        List<Category> GetAllCategories(bool showHidden);
        
        /// <summary>
        /// Gets all categories by parent category identifier
        /// </summary>
        /// <param name="parentCategoryId">Parent category identifier</param>
        /// <returns>Category collection</returns>
        List<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId);
        
        /// <summary>
        /// Gets all categories filtered by parent category identifier
        /// </summary>
        /// <param name="parentCategoryId">Parent category identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Category collection</returns>
        List<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId,
            bool showHidden);
        
        /// <summary>
        /// Gets all categories displayed on the home page
        /// </summary>
        /// <returns>Categories</returns>
        List<Category> GetAllCategoriesDisplayedOnHomePage();
                
        /// <summary>
        /// Gets a category
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <returns>Category</returns>
        Category GetCategoryById(int categoryId);

        /// <summary>
        /// Inserts category
        /// </summary>
        /// <param name="category">Category</param>
        void InsertCategory(Category category);

        /// <summary>
        /// Updates the category
        /// </summary>
        /// <param name="category">Category</param>
        void UpdateCategory(Category category);

        /// <summary>
        /// Gets localized category by id
        /// </summary>
        /// <param name="localizedCategoryId">Localized category identifier</param>
        /// <returns>Category content</returns>
        LocalizedCategory GetLocalizedCategoryById(int localizedCategoryId);

        /// <summary>
        /// Gets localized category by category id
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <returns>Category content</returns>
        List<LocalizedCategory> GetLocalizedCategoriesByCategoryId(int categoryId);

        /// <summary>
        /// Gets localized category by category id and language id
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Category content</returns>
        LocalizedCategory GetCategoryLocalizedByCategoryIdAndLanguageId(int categoryId, int languageId);

        /// <summary>
        /// Inserts a localized category
        /// </summary>
        /// <param name="localizedCategory">Localized category</param>
        void InsertLocalizedCategory(LocalizedCategory localizedCategory);

        /// <summary>
        /// Update a localized category
        /// </summary>
        /// <param name="localizedCategory">Localized category</param>
        void UpdateLocalizedCategory(LocalizedCategory localizedCategory);
        
        /// <summary>
        /// Deletes a product category mapping
        /// </summary>
        /// <param name="productCategory">Product category</param>
        void DeleteProductCategory(ProductCategory productCategory);

        /// <summary>
        /// Gets product category mapping collection
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <returns>Product a category mapping collection</returns>
        List<ProductCategory> GetProductCategoriesByCategoryId(int categoryId);

        /// <summary>
        /// Gets a product category mapping collection
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>Product category mapping collection</returns>
        List<ProductCategory> GetProductCategoriesByProductId(int productId);

        /// <summary>
        /// Gets a product category mapping 
        /// </summary>
        /// <param name="productCategoryId">Product category mapping identifier</param>
        /// <returns>Product category mapping</returns>
        ProductCategory GetProductCategoryById(int productCategoryId);

        /// <summary>
        /// Inserts a product category mapping
        /// </summary>
        /// <param name="productCategory">>Product category mapping</param>
        void InsertProductCategory(ProductCategory productCategory);

        /// <summary>
        /// Updates the product category mapping 
        /// </summary>
        /// <param name="productCategory">>Product category mapping</param>
        void UpdateProductCategory(ProductCategory productCategory);
    }
}
