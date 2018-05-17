using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Common;

namespace Nop.Data.Mapping.Common
{
    /// <summary>
    /// Represents a decimal query type mapping configuration
    /// </summary>
    public partial class DecimalQueryTypeMap : NopQueryTypeConfiguration<DecimalQueryType>
    {
        #region Methods

        /// <summary>
        /// Configures the query type
        /// </summary>
        /// <param name="builder">The builder to be used to configure the query type</param>
        public override void Configure(QueryTypeBuilder<DecimalQueryType> builder)
        {
            //add custom configuration
            this.PostConfigure(builder);
        }

        #endregion
    }
}