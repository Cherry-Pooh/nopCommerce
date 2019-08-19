﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ProductReviewReviewTypeMappingMap : NopEntityTypeConfiguration<ProductReviewReviewTypeMapping>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ProductReviewReviewTypeMapping> builder)
        {
            builder.ToTable(NopMappingDefaults.ProductReview_ReviewTypeTable);
            builder.HasKey(prrt => prrt.Id);

            base.Configure(builder);
        }

        #endregion
    }
}
