﻿using System.Threading.Tasks;
using Nop.Core.Domain.Topics;
using Nop.Services.Caching;

namespace Nop.Services.Topics.Caching
{
    /// <summary>
    /// Represents a topic template cache event consumer
    /// </summary>
    public partial class TopicTemplateCacheEventConsumer : CacheEventConsumer<TopicTemplate>
    {
        /// <summary>
        /// entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="entityEventType">Entity event type</param>
        protected override async Task ClearCache(TopicTemplate entity, EntityEventType entityEventType)
        {
            await Remove(NopTopicDefaults.TopicTemplatesAllCacheKey);
        }
    }
}
