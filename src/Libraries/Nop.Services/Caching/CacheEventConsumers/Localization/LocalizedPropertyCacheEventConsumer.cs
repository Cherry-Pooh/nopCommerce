﻿using Nop.Core.Domain.Localization;
using Nop.Services.Caching.CachingDefaults;

namespace Nop.Services.Caching.CacheEventConsumers.Localization
{
    public partial class LocalizedPropertyCacheEventConsumer : CacheEventConsumer<LocalizedProperty>
    {
        public override void ClearCache(LocalizedProperty entity)
        {
            RemoveByPrefix(NopLocalizationCachingDefaults.LocalizedPropertyPrefixCacheKey);
        }
    }
}
