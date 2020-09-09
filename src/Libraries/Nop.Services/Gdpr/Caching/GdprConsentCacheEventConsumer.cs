﻿using System.Threading.Tasks;
using Nop.Core.Domain.Gdpr;
using Nop.Services.Caching;

namespace Nop.Services.Gdpr.Caching
{
    /// <summary>
    /// Represents a GDPR consent cache event consumer
    /// </summary>
    public partial class GdprConsentCacheEventConsumer : CacheEventConsumer<GdprConsent>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override async Task ClearCache(GdprConsent entity)
        {
            await Remove(NopGdprDefaults.ConsentsAllCacheKey);
        }
    }
}