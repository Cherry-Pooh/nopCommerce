﻿using Nop.Core.Configuration;

namespace Nop.Core.Domain.Forums
{
    public class ForumSettings : ISettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether forums are enabled
        /// </summary>
        public bool ForumsEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether relative date and time formatting is enabled  (e.g. 2 hours ago, a month ago)
        /// </summary>
        public bool RelativeDateTimeFormattingEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to edit posts that they created.
        /// </summary>
        public bool AllowCustomersToEditPosts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to manage theirs subscriptions
        /// </summary>
        public bool AllowCustomersToManageSubscriptions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the guests are allowed to create posts.
        /// </summary>
        public bool AllowGuestsToCreatePosts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the guests are allowed to create topics.
        /// </summary>
        public bool AllowGuestsToCreateTopics { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to delete posts that they created.
        /// </summary>
        public bool AllowCustomersToDeletePosts { get; set; }

        /// <summary>
        /// Gets or sets maximum length of topic subject
        /// </summary>
        public int TopicSubjectMaxLength { get; set; }

        /// <summary>
        /// Gets or sets maximum length of post
        /// </summary>
        public int PostMaxLength { get; set; }

        /// <summary>
        /// Gets or sets the page size for topics in forums
        /// </summary>
        public int TopicsPageSize { get; set; }

        /// <summary>
        /// Gets or sets the page size for posts in topics
        /// </summary>
        public int PostsPageSize { get; set; }

        /// <summary>
        /// Gets or sets the number of links to display for pagination of posts in topics
        /// </summary>
        public int TopicPostsPageLinkDisplayCount { get; set; }

        /// <summary>
        /// Gets or sets the number of links to display for pagination of topics in forums
        /// </summary>
        public int ForumTopicsPageLinkDisplayCount { get; set; }

        /// <summary>
        /// Gets or sets the number of links to display for pagination of topics in search results
        /// </summary>
        public int SearchPageLinkDisplayCount { get; set; }

        /// <summary>
        /// Gets or sets the page size for search result
        /// </summary>
        public int SearchResultsPageSize { get; set; }

        /// <summary>
        /// Gets or sets the page size for latest user post
        /// </summary>
        public int LatestUserPostsPageSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show customers forum post count
        /// </summary>
        public bool ShowCustomersPostCount { get; set; }

        /// <summary>
        /// Gets or sets a forum editor type
        /// </summary>
        public EditorTypeEnum ForumEditor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to specify signature.
        /// </summary>
        public bool SignaturesEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether private messages are allowed
        /// </summary>
        public bool AllowPrivateMessages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a customer should be notified about new private messages
        /// </summary>
        public bool NotifyAboutPrivateMessages { get; set; }

        /// <summary>
        /// Gets or sets maximum length of pm subject
        /// </summary>
        public int PMSubjectMaxLength { get; set; }

        /// <summary>
        /// Gets or sets maximum length of pm message
        /// </summary>
        public int PMTextMaxLength { get; set; }

        /// <summary>
        /// Gets or sets the number of items to display for Active Discussions
        /// </summary>
        public int ActiveDiscussionsCount { get; set; }

        /// <summary>
        /// Gets or sets the number of items to display for Active Discussions RSS Feed
        /// </summary>
        public int ActiveDiscussionsFeedCount { get; set; }

        /// <summary>
        /// Gets or sets the number of items to display for Forum RSS Feed
        /// </summary>
        public int ForumFeedCount { get; set; }

        /// <summary>
        /// Gets or sets the minimum length for search term
        /// </summary>
        public int ForumSearchTermMinimumLength { get; set; }
    }
}
