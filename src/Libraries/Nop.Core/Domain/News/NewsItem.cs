using System;
using System.Collections.Generic;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.News
{
    /// <summary>
    /// Represents a news item
    /// </summary>
    public partial class NewsItem : BaseEntity, ISlugSupported, IStoreMappingSupported
    {
        private ICollection<NewsComment> _newsComments;

        /// <summary>
        /// Gets or sets the language identifier
        /// </summary>
        public virtual int LanguageId { get; set; }

        /// <summary>
        /// Gets or sets the news title
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets the short text
        /// </summary>
        public virtual string Short { get; set; }

        /// <summary>
        /// Gets or sets the full text
        /// </summary>
        public virtual string Full { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the news item is published
        /// </summary>
        public virtual bool Published { get; set; }

        /// <summary>
        /// Gets or sets the news item start date and time
        /// </summary>
        public virtual DateTime? StartDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the news item end date and time
        /// </summary>
        public virtual DateTime? EndDateUtc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the news post comments are allowed 
        /// </summary>
        public virtual bool AllowComments { get; set; }

        /// <summary>
        /// Gets or sets the total number of approved comments
        /// <remarks>The same as if we run newsItem.NewsComments.Where(n => n.IsApproved).Count()
        /// We use this property for performance optimization (no SQL command executed)
        /// </remarks>
        /// </summary>
        public virtual int ApprovedCommentCount { get; set; }
        /// <summary>
        /// Gets or sets the total number of not approved comments
        /// <remarks>The same as if we run newsItem.NewsComments.Where(n => !n.IsApproved).Count()
        /// We use this property for performance optimization (no SQL command executed)
        /// </remarks>
        /// </summary>
        public virtual int NotApprovedCommentCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
        /// </summary>
        public virtual bool LimitedToStores { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        public virtual DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the news comments
        /// </summary>
        public virtual ICollection<NewsComment> NewsComments
        {
            get { return _newsComments ?? (_newsComments = new List<NewsComment>()); }
            protected set { _newsComments = value; }
        }
        
        /// <summary>
        /// Gets or sets the language
        /// </summary>
        public virtual Language Language { get; set; }
    }
}