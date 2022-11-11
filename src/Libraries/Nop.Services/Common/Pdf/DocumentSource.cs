using Nop.Core.Domain.Localization;
using QuestPDF.Helpers;

namespace Nop.Services.Common.Pdf
{
    /// <summary>
    /// Represents the data source for an underlying PDF document
    /// </summary>
    public class DocumentSource
    {
        /// <summary>
        /// Gets or sets the language context
        /// </summary>
        public required Language Language { get; set; }

        /// <summary>
        /// Gets or sets the page size
        /// </summary>
        public required PageSize PageSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating that the text direction is from right to left
        /// </summary>
        public bool IsRightToLeft => Language.Rtl;
    }
}