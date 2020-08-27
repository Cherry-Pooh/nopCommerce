﻿using System;
using FluentAssertions;
using Nop.Core.Domain.News;
using Nop.Services.News;
using Nop.Tests;
using NUnit.Framework;

namespace Nop.Services.Tests.News
{
    [TestFixture]
    public class NewsServiceTests : ServiceTest
    {
        private INewsService _newsService;

        [SetUp]
        public new void SetUp()
        {
            _newsService = new NewsService(null, null, null, null, new TestCacheManager());
        }

        [Test]
        public void Should_be_available_when_startdate_is_not_set()
        {
            var newsItem = new NewsItem
            {
                StartDateUtc = null
            };

            _newsService.IsNewsAvailable(newsItem, new DateTime(2010, 01, 03)).Should().BeTrue();
        }

        [Test]
        public void Should_be_available_when_startdate_is_less_than_somedate()
        {
            var newsItem = new NewsItem
            {
                StartDateUtc = new DateTime(2010, 01, 02)
            };

            _newsService.IsNewsAvailable(newsItem, new DateTime(2010, 01, 03)).Should().BeTrue();
        }

        [Test]
        public void Should_not_be_available_when_startdate_is_greater_than_somedate()
        {
            var newsItem = new NewsItem
            {
                StartDateUtc = new DateTime(2010, 01, 02)
            };

            _newsService.IsNewsAvailable(newsItem, new DateTime(2010, 01, 01)).Should().BeFalse();
        }

        [Test]
        public void Should_be_available_when_enddate_is_not_set()
        {
            var newsItem = new NewsItem
            {
                EndDateUtc = null
            };

            _newsService.IsNewsAvailable(newsItem, new DateTime(2010, 01, 03)).Should().BeTrue();
        }

        [Test]
        public void Should_be_available_when_enddate_is_greater_than_somedate()
        {
            var newsItem = new NewsItem
            {
                EndDateUtc = new DateTime(2010, 01, 02)
            };

            _newsService.IsNewsAvailable(newsItem, new DateTime(2010, 01, 01)).Should().BeTrue();
        }

        [Test]
        public void Should_not_be_available_when_enddate_is_less_than_somedate()
        {
            var newsItem = new NewsItem
            {
                EndDateUtc = new DateTime(2010, 01, 02)
            };

            _newsService.IsNewsAvailable(newsItem, new DateTime(2010, 01, 03)).Should().BeFalse();
        }
    }
}
