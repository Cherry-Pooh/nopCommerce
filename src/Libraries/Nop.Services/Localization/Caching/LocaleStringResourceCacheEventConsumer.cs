﻿using Nop.Core.Domain.Localization;
using Nop.Services.Caching;

namespace Nop.Services.Localization.Caching
{
    /// <summary>
    /// Represents a locale string resource cache event consumer
    /// </summary>
    public partial class LocaleStringResourceCacheEventConsumer : CacheEventConsumer<LocaleStringResource>
    {
        /// <summary>
        /// Clear cache by entity event type
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(LocaleStringResource entity)
        {
            Remove(_staticCacheManager.PrepareKey(NopLocalizationDefaults.LocaleStringResourcesAllPublicCacheKey, entity.LanguageId));
            Remove(_staticCacheManager.PrepareKey(NopLocalizationDefaults.LocaleStringResourcesAllAdminCacheKey, entity.LanguageId));
            Remove(_staticCacheManager.PrepareKey(NopLocalizationDefaults.LocaleStringResourcesAllCacheKey, entity.LanguageId));
            RemoveByPrefix(_staticCacheManager.PrepareKeyPrefix(NopLocalizationDefaults.LocaleStringResourcesByNamePrefix, entity.LanguageId));
        }
    }
}
