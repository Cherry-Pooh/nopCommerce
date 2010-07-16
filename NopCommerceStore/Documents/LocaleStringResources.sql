﻿--new locale resources
declare @resources xml
set @resources='
<Language LanguageID="7">
  <LocaleResource Name="Admin.Categories.DisplayOrder">
    <Value>Display Order</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.Other.HideNewsletterBox">
    <Value>Hide newsletter box:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.Other.HideNewsletterBox.Tooltip">
    <Value>Check if you want to hide the newsletter subscription box</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PublicStore">
    <Value>Public Store</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.LoggedInAs">
    <Value>Logged in as:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.Logout">
    <Value>Logout?</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ClearCacheButton.Text">
    <Value>Clear Cache</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.RewardPoints.EarningRewardPoints.Tooltip1">
    <Value>Each</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.RewardPoints.EarningRewardPoints.Tooltip2">
    <Value>spent will earn</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.RewardPoints.EarningRewardPoints.Tooltip3">
    <Value>reward points.</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.Topics.IsPasswordProtected">
    <Value>Password protected</Value>
  </LocaleResource>
  <LocaleResource Name="TopicPage.btnPassword.Text">
    <Value>Enter</Value>
  </LocaleResource>
  <LocaleResource Name="TopicPage.WrongPassword">
    <Value>Wrong password</Value>
  </LocaleResource>
  <LocaleResource Name="TopicPage.EnterPassword">
    <Value>Please enter password to access this page:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TopicInfo.IsPasswordProtected">
    <Value>Is password protected:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TopicInfo.IsPasswordProtected.Tooltip">
    <Value>Check if this topic is password proceted</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TopicInfo.Password">
    <Value>Password:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TopicInfo.Password.Tooltip">
    <Value>The password to access the content of this topic</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TopicInfo.Url">
    <Value>URL:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TopicInfo.Url.Tooltip">
    <Value>The URL of this topic</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PromotionsHome.NewsletterSubscribers.TitleDescription">
    <Value>Newsletter Subscribers</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PromotionsHome.NewsletterSubscribers.Title">
    <Value>Newsletter Subscribers</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PromotionsHome.NewsletterSubscribers.Description">
    <Value>Manage the newsletter subscribers here.</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.NewsletterSubscribers.Title">
    <Value>Newsletter Subscribers</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.NewsletterSubscribers.SearchButton.Text">
    <Value>Search</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.NewsletterSubscribers.DeleteButton.Text">
    <Value>Delete selected</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.NewsletterSubscribers.Email">
    <Value>Email:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.NewsletterSubscribers.Email.Tooltip">
    <Value>Enter email to find or leave empty to load all subscribers</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.NewsletterSubscribers.EmailColumn">
    <Value>Email</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.NewsletterSubscribers.Active">
    <Value>Active</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.NewsletterSubscribers.SubscribedOnColumn">
    <Value>Subscribed on</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.Sitemap.NewsletterSubscribersTitle">
    <Value>Newsletter Subscribers</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.Sitemap.NewsletterSubscribersDescription">
    <Value>Manage Newsletter Subscribers</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.Campaigns.ExportEmailsButton.Text">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.Campaigns.ExportEmailsButton.Tooltip">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.NewsletterSubscribers.ExportEmailsButton.Text">
    <Value>Export emails to CSV</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.NewsletterSubscribers.ExportEmailsButton.Tooltip">
    <Value>Export emails subscribed to newsletters to a comma-separated value (CSV) file.</Value>
  </LocaleResource>
  <LocaleResource Name="ShoppingCart.GiftCards.DontWorkWithAutoshipProducts">
    <Value>You cannot use gift cards with auto-ship (recurring) items.</Value>
  </LocaleResource>
  <LocaleResource Name="ForumSubscriptions.InfoColumn">
    <Value>Forum/Topic</Value>
  </LocaleResource>
  <LocaleResource Name="ForumSubscriptions.DeleteSelected">
    <Value>Delete Selected</Value>
  </LocaleResource>
  <LocaleResource Name="Account.ForumSubscriptions">
    <Value>Forum Subscriptions</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ForumsSettings.AllowToManageSubscriptions">
    <Value>Allow customers to manage forum subscriptions:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ForumsSettings.AllowToManageSubscriptions.Tooltip">
    <Value>Check if you want to allow customers to manage forum subscriptions</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CustomerForumSubscriptions.InfoColumn">
    <Value>Forum/Topic</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CustomerForumSubscriptions.DeleteColumn">
    <Value>Delete</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CustomerDetails.CustomerForumSubscriptions">
    <Value>Forum Subscriptions</Value>
  </LocaleResource>
  <LocaleResource Name="">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.BulkEditProducts.PriceColumn.RangeErrorMessage">
    <Value>The price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.BulkEditProducts.OldPriceColumn.RangeErrorMessage">
    <Value>The old price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CheckoutAttributeInfo.PriceAdjustment.RangeErrorMessage">
    <Value>The price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CheckoutAttributeValues.New.PriceAdjustment.RangeErrorMessage">
    <Value>The price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.DiscountInfo.DiscountAmount.RangeErrorMessage">
    <Value>The amount must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GiftCardInfo.InitialValue.RangeErrorMessage">
    <Value>The initial value must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PricelistInfo.PriceAdjustment.RangeErrorMessage">
    <Value>The price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PricelistInfo.ProductVariants.PriceAdjustment.RangeErrorMessage">
    <Value>The price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.Price.RangeErrorMessage">
    <Value>The price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.OldPrice.RangeErrorMessage">
    <Value>The old price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.ProductCost.RangeErrorMessage">
    <Value>The product cost must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.MinimumCustomerEnteredPrice.RangeErrorMessage">
    <Value>The price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.MaximumCustomerEnteredPrice.RangeErrorMessage">
    <Value>The price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.AdditionalShippingCharge.RangeErrorMessage">
    <Value>The additional shipping charge must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductPricesByCustomerRole.Price.RangeErrorMessage">
    <Value>The price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductPricesByCustomerRole.New.Price.RangeErrorMessage">
    <Value>The price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantAttributeValues.PriceAdjustment.RangeErrorMessage">
    <Value>The price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantAttributeValues.New.PriceAdjustment.RangeErrorMessage">
    <Value>The price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.Price.RangeErrorMessage">
    <Value>The price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.OldPrice.RangeErrorMessage">
    <Value>The old price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.ProductCost.RangeErrorMessage">
    <Value>The product cost must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.MinimumCustomerEnteredPrice.RangeErrorMessage">
    <Value>The price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.MaximumCustomerEnteredPrice.RangeErrorMessage">
    <Value>The price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.AdditionalShippingCharge.RangeErrorMessage">
    <Value>The additional shipping charge must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantTierPrices.Price.RangeErrorMessage">
    <Value>The price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantTierPrices.New.Price.RangeErrorMessage">
    <Value>The price must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ShippingSettings.ValueOfX.RangeErrorMessage">
    <Value>The value must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Products.QuantityRange">
    <Value>The quantity must be from 1 to 9999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CategoryInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CategorySEO.PageSize.RangeErrorMessage">
    <Value>The page size must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CategoryProducts.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.MaxNumberOfDownloads.RangeErrorMessage">
    <Value>The value must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.StockQuantity.RangeErrorMessage">
    <Value>The stock quantity must be from -999999 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.MinStockQuantity.RangeErrorMessage">
    <Value>The value must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.NotifyForQuantityBelow.RangeErrorMessage">
    <Value>The value must be from 1 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.OrderMinimumQuantity.RangeErrorMessage">
    <Value>The value must be from 1 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.OrderMaximumQuantity.RangeErrorMessage">
    <Value>The value must be from 1 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.Weight.RangeErrorMessage">
    <Value>The weight must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.Length.RangeErrorMessage">
    <Value>The length must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.Width.RangeErrorMessage">
    <Value>The width must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.Height.RangeErrorMessage">
    <Value>The height must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductCategory.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductManufacturer.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.RelatedProducts.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductPictures.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductPictures.New.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductSpecifications.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductSpecifications.New.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.StockQuantity.RangeErrorMessage">
    <Value>The stock quantity must be from -999999 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.MinStockQuantity.RangeErrorMessage">
    <Value>The value must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.NotifyForQuantityBelow.RangeErrorMessage">
    <Value>The value must be from 1 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.OrderMinimumQuantity.RangeErrorMessage">
    <Value>The value must be from 1 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.OrderMaximumQuantity.RangeErrorMessage">
    <Value>The value must be from 1 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.Weight.RangeErrorMessage">
    <Value>The weight must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.Length.RangeErrorMessage">
    <Value>The length must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.Width.RangeErrorMessage">
    <Value>The width must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.Height.RangeErrorMessage">
    <Value>The height must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantTierPrices.Quantity.RangeErrorMessage">
    <Value>The quantity must be from 0 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantTierPrices.New.Quantity.RangeErrorMessage">
    <Value>The quantity must be from 0 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantAttributes.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantAttributes.New.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantAttributeValues.WeightAdjustment.RangeErrorMessage">
    <Value>The weight adjustment must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantAttributeValues.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantAttributeValues.New.WeightAdjustment.RangeErrorMessage">
    <Value>The weight adjustment must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantAttributeValues.New.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SpecificationAttributeInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ManufacturerInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ManufacturerSEO.PageSize.RangeErrorMessage">
    <Value>The page size must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ManufacturerProducts.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PricelistInfo.CacheTime.RangeErrorMessage">
    <Value>The cache time must be from 0 to 64000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PollInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PollInfo.DisplayOrderColumn.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PollInfo.New.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ForumsSettings.TopicsPageSize.RangeErrorMessage">
    <Value>The page size must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ForumsSettings.PostsPageSize.RangeErrorMessage">
    <Value>The page size must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ForumGroupInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ForumInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductTemplateInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CategoryTemplateInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ManufacturerTemplateInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.Media.MaxImageSize.RangeErrorMessage">
    <Value>The value must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.Media.ProductThumbSize.RangeErrorMessage">
    <Value>The value must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.Media.ProductDetailSize.RangeErrorMessage">
    <Value>The value must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.Media.ProductVariantSize.RangeErrorMessage">
    <Value>The value must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.Media.CategoryThumbSize.RangeErrorMessage">
    <Value>The value must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.Media.ManufacturerThumbSize.RangeErrorMessage">
    <Value>The value must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.Media.CartThumbSize.RangeErrorMessage">
    <Value>The value must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.Other.AlsoPurchasedNumber.RangeErrorMessage">
    <Value>The value must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CreditCardTypeInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PaymentMethodInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TaxProviderInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TaxCategoryInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ShippingMethodInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ShippingRateComputationMethodInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CountryInfo.NumbericISOCode.RangeErrorMessage">
    <Value>The numberic ISO code must be from 1 to 9999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CountryInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.StateProvinceInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.LanguageInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.Currencies.LiveRates.Rate.RangeErrorMessage">
    <Value>The rate must be from 0 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CurrencyInfo.Rate.RangeErrorMessage">
    <Value>The rate must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CurrencyInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.MessageQueue.MaxSendTries.RangeErrorMessage">
    <Value>The value must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.MessageQueueDetails.Priority.RangeErrorMessage">
    <Value>The priority must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.MessageQueueDetails.SendTries.RangeErrorMessage">
    <Value>The value must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.AddRelatedProduct.DisplayOrderColumn.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.AddCategoryProduct.DisplayOrderColumn.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.AddManufacturerProduct.DisplayOrderColumn.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.MeasureDimensionInfo.Ratio.RangeErrorMessage">
    <Value>The ratio must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.MeasureDimensionInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.MeasureWeightInfo.Ratio.RangeErrorMessage">
    <Value>The ratio must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.MeasureWeightInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.CycleLength.RangeErrorMessage">
    <Value>The cycle length must be from 1 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.TotalCycles.RangeErrorMessage">
    <Value>The total cycles must be from 1 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.CycleLength.RangeErrorMessage">
    <Value>The cycle length must be from 1 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.TotalCycles.RangeErrorMessage">
    <Value>The total cycles must be from 1 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.RecurringPaymentInfo.CycleLength.RangeErrorMessage">
    <Value>The cycle length must be from 1 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.RecurringPaymentInfo.TotalCycles.RangeErrorMessage">
    <Value>The total cycles must be from 1 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.Other.RecentlyViewedProductsNumber.RangeErrorMessage">
    <Value>The value must be from 1 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.Other.RecentlyAddedProductsNumber.RangeErrorMessage">
    <Value>The value must be from 1 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.Other.ShowBestsellersOnHomePageNumber.RangeErrorMessage">
    <Value>The value must be from 1 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantAttributes.Combinations.StockQuantity.RangeErrorMessage">
    <Value>The stock quantity must be from -999999 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantAttributes.CombinationsGrid.StockQuantity.RangeErrorMessage">
    <Value>The stock quantity must be from -999999 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.BlogSettings.PostsPageSize.RangeErrorMessage">
    <Value>The page size must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CheckoutAttributeInfo.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CheckoutAttributeValues.New.WeightAdjustment.RangeErrorMessage">
    <Value>The weight adjustment must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CheckoutAttributeValues.New.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CheckoutAttributeInfo.WeightAdjustment.RangeErrorMessage">
    <Value>The weight adjustment must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.RewardPoints.PointsForRegistration.RangeErrorMessage">
    <Value>The value must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.RewardPoints.PointsForPurchases_Amount.RangeErrorMessage">
    <Value>The value must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.RewardPoints.PointsForPurchases_Points.RangeErrorMessage">
    <Value>The value must be from 0 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CustomerRewardPoints.Add.Points.RangeErrorMessage">
    <Value>The value must be from -999999 to 999999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SpecificationAttributeOptions.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SpecificationAttributeOptions.New.DisplayOrder.RangeErrorMessage">
    <Value>The display order must be from -99999 to 99999</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.DisplayStockQuantity">
    <Value>Display stock quantity:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.DisplayStockQuantity.Tooltip">
    <Value>Check to display stock quantity. When enabled, customers will see stock quantity.</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.DisplayStockQuantity">
    <Value>Display stock quantity:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.DisplayStockQuantity.Tooltip">
    <Value>Check to display stock quantity. When enabled, customers will see stock quantity.</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.DisplayStockAvailability">
    <Value>Display stock availability:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.DisplayStockAvailability">
    <Value>Display stock availability:</Value>
  </LocaleResource>
  <LocaleResource Name="Products.InStockWithQuantity">
    <Value>{0} in stock</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.SEODisplay.EnableUrlRewriting">
    <Value>URL rewriting enabled:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.SEODisplay.EnableUrlRewriting.Tooltip">
    <Value>Check to enable URL rewriting</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.DiscountInfo.RequirementSpentAmount">
    <Value>Required spent amount:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.DiscountInfo.RequirementSpentAmount.Tooltip">
    <Value>Discount will be applied if customer has spent/purchased x.xx amount.</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.DiscountInfo.RequirementSpentAmount.RequiredErrorMessage">
    <Value>Enter required spent amount</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.DiscountInfo.RequirementSpentAmount.RangeErrorMessage">
    <Value>The value must be from 0 to 100000000</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.AllowOutOfStockOrders">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.AllowOutOfStockOrders.Tooltip">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.Backorders">
    <Value>Backorders:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.Backorders.Tooltip">
    <Value>Select backorder mode.</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.AllowOutOfStockOrders">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.AllowOutOfStockOrders.Tooltip">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.Backorders">
    <Value>Backorders:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.Backorders.Tooltip">
    <Value>Select backorder mode.</Value>
  </LocaleResource>
  <LocaleResource Name="Products.Backordering">
    <Value>Out of Stock - on backorder and will be despatched once in stock.</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductBackorderMode.NoBackorders">
    <Value>No backorders</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductBackorderMode.AllowQtyBelow0">
    <Value>Allow qty below 0</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductBackorderMode.AllowQtyBelow0AndNotifyCustomer">
    <Value>Allow qty below 0 and notify customer</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ForumsSettings.AllowGuestsToCreatePosts">
    <Value>Allow guests to create posts:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ForumsSettings.AllowGuestsToCreateTopics">
    <Value>Allow guests to create topics:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.GiftCardType">
    <Value>Gift card type:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.GiftCardType.Tooltip">
    <Value>Select gift card type. WARNING: not recommended to change in production environment.</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.GiftCardType">
    <Value>Gift card type:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductVariantInfo.GiftCardType.Tooltip">
    <Value>Select gift card type. WARNING: not recommended to change in production environment.</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.ProductType">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ProductInfo.ProductType.Tooltip">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.Currencies.ExchangeRateProvider">
    <Value>Current exchange rate provider:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.Currencies.SaveExchangeRateProviderButton">
    <Value>Save</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Title">
    <Value>SMS Providers</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.SaveButton.Text">
    <Value>Save</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.SaveButton.Tooltip">
    <Value>Save changes</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Clickatell.Title">
    <Value>Clickatell</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviderInfo.Name">
    <Value>Name:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviderInfo.Name.Tooltip">
    <Value>SMS provider name</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviderInfo.Name.ErrorMessage">
    <Value>Name is required</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviderInfo.ClassName">
    <Value>Class name:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviderInfo.ClassName.Tooltip">
    <Value>Enter fully qualified name of SMS provider class</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviderInfo.ClassName.ErrorMessage">
    <Value>Class name is required</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviderInfo.SystemKeyword">
    <Value>System keyword:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviderInfo.SystemKeyword.Tooltip">
    <Value>SMS provider system keywork</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviderInfo.Active">
    <Value>Active:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviderInfo.Active.Tooltip">
    <Value>Determines whether this SMS provider is active.</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.SMSAlerts.Title">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.SMSAlerts.Enabled">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.SMSAlerts.Enabled.Tooltip">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.SMSAlerts.PhoneNumber">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.SMSAlerts.PhoneNumber.Tooltip">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.SMSAlerts.Clickatell.APIID">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.SMSAlerts.Clickatell.APIID.Tooltip">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.SMSAlerts.Clickatell.Username">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.SMSAlerts.Clickatell.Username.Tooltip">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.SMSAlerts.Clickatell.Password">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.SMSAlerts.Clickatell.Password.Tooltip">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.SMSAlerts.TestPhone">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.SMSAlerts.TestPhone.Tooltip">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.SMSAlerts.SendTestSMSButton">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.GlobalSettings.SMSAlerts.SendTestSMSButton.Tooltip">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Clickatell.PhoneNumber">
    <Value>Phone number:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Clickatell.PhoneNumber.Tooltip">
    <Value>Your phone number</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Clickatell.APIID">
    <Value>API ID:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Clickatell.APIID.Tooltip">
    <Value>Clickatell API ID</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Clickatell.Username">
    <Value>Username:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Clickatell.Username.Tooltip">
    <Value>Clickatell username</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Clickatell.Password">
    <Value>Password:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Clickatell.Password.Tooltip">
    <Value>Clickatell password</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Clickatell.TestMessage">
    <Value>Send test message</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Clickatell.TestMessage.Text">
    <Value>Message text:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Clickatell.TestMessage.Text.Tooltip">
    <Value>Text of test message</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Clickatell.TestMessage.SendButton">
    <Value>Send</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Clickatell.TestMessage.SendButton.Tooltip">
    <Value>Click here to send test message</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Clickatell.TestMessage.Success">
    <Value>Test message was sent</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Clickatell.TestMessage.Failed">
    <Value>Test message sending failed</Value>
  </LocaleResource>
  <LocaleResource Name="ActivityLog.EditSMSProviders">
    <Value>SMS providers settings were changed</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.Sitemap.SMSProvidersTitle">
    <Value>SMS Providers</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.Sitemap.SMSProvidersDescription">
    <Value>Manage SMS Providers</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TaxSettings.EUVatEnabled">
    <Value>EU VAT enabled:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TaxSettings.EUVatEnabled.Tooltip">
    <Value>Check to enable EU VAT (the European Union Value Added Tax).</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TaxSettings.EUVatShopCountry">
    <Value>Your shop country:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TaxSettings.EUVatShopCountry.Tooltip">
    <Value>Select your shop country for VAT calculation</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TaxSettings.EUVatAllowVATExemption">
    <Value>Allow VAT exemption:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TaxSettings.EUVatAllowVATExemption.Tooltip">
    <Value>Check if this store will exempt eligible VAT-registered customers from VAT</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TaxSettings.EUVatUseWebService">
    <Value>Use web service:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TaxSettings.EUVatUseWebService.Tooltip">
    <Value>Check if you want to use the EU web service to validate VAT numbers. WARNING: If this option is enabled, then DO NOT disable country form field available during registration (public store).</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TaxSettings.EUVatEmailAdminWhenNewVATSubmitted">
    <Value>Notify admin when a new VAT number is submitted:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TaxSettings.EUVatEmailAdminWhenNewVATSubmitted.Tooltip">
    <Value>Check if you want to receive a notification (email) when a new VAT number is submitted</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.TaxSettings.EUVatShopCountry.SelectCountry">
    <Value>Select country</Value>
  </LocaleResource>
  <LocaleResource Name="Account.VATNumber">
    <Value>VAT number</Value>
  </LocaleResource>
  <LocaleResource Name="Account.VATNumberStatus">
    <Value>(status: {0})</Value>
  </LocaleResource>
  <LocaleResource Name="VatNumberStatus.Unknown">
    <Value>Unknown</Value>
  </LocaleResource>
  <LocaleResource Name="VatNumberStatus.Empty">
    <Value>Empty</Value>
  </LocaleResource>
  <LocaleResource Name="VatNumberStatus.Valid">
    <Value>Valid</Value>
  </LocaleResource>
  <LocaleResource Name="VatNumberStatus.Invalid">
    <Value>Invalid</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ConfigurationHome.SMSProviders.TitleDescription">
    <Value>SMS Providers</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ConfigurationHome.SMSProviders.Title">
    <Value>SMS Providers</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.ConfigurationHome.SMSProviders.Description">
    <Value>Manage SMS notification settings and providers.</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CustomerInfo.VatNumber">
    <Value>VAT number:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CustomerInfo.VatNumber.Tooltip">
    <Value>Enter company VAT number</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CustomerInfo.VATNumberStatus">
    <Value>(status: {0})</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CustomerInfo.BtnMarkVatNumberAsValid.Text">
    <Value>Mark VAT number as valid</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CustomerInfo.BtnMarkVatNumberAsInvalid.Text">
    <Value>Mark VAT number as invalid</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.Countries.SubjectToVAT">
    <Value>Subject to VAT</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CountryInfo.SubjectToVAT">
    <Value>Subject to VAT:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CountryInfo.SubjectToVAT.Tooltip">
    <Value>Value indicating whether customers in this country must be charged EU VAT (the European Union Value Added Tax)</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.OrderDetails.VatNumber">
    <Value>VAT number:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.OrderDetails.VatNumber.Tooltip">
    <Value>Used VAT number (the European Union Value Added Tax)</Value>
  </LocaleResource>
  <LocaleResource Name="Order.VATNumber">
    <Value>VAT number</Value>
  </LocaleResource>
  <LocaleResource Name="PDFInvoice.VATNumber">
    <Value>VAT number: {0}</Value>
  </LocaleResource>
  <LocaleResource Name="Order.ShippedOn">
    <Value>Shipped on</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Verizon.Title">
    <Value>Verizon</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Verizon.Email">
    <Value>Email:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Verizon.Email.Tooltip">
    <Value>Verizon email address(e.g. your_phone_number@vtext.com)</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Verizon.TestMessage">
    <Value>Send test message</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Verizon.TestMessage.Text">
    <Value>Text:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Verizon.TestMessageText.Tooltip">
    <Value>Text of the test message</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Verizon.TestMessage.SendButton">
    <Value>Send</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Verizon.TestMessage.SendButton.Tooltip">
    <Value>Click to send test message</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Verizon.TestMessage.Failed">
    <Value>Test message sending failed</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SMSProviders.Verizon.TestMessage.Success">
    <Value>Test message was sent</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.NewsletterSubscribers.ImportCSV.CSVFile">
    <Value>CSV (tab-delimited) file:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.NewsletterSubscribers.ImportEmailsButton.Text">
    <Value>Import emails from CSV</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.NewsletterSubscribers.ImportEmailsButton.Tooltip">
    <Value>Import emails from CSV(tab-delimeted) file</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.NewsletterSubscribers.ImportEmailsButton.Success">
    <Value>{0} emails have been successfully imported</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CurrentShoppingCarts.Title">
    <Value>Current Shopping Carts</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CurrentShoppingCarts.Empty">
    <Value>No records found</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.Sitemap.CurrentShoppingCartsTitle">
    <Value>Current Shopping Carts</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.Sitemap.CurrentShoppingCartsDescription">
    <Value>Manage Current Shopping Carts</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CustomerShoppingCart.CustomerColumn">
    <Value>Customer</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CustomerShoppingCart.CustomerColumn.Guest">
    <Value>Guest</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CustomerShoppingCart.NameColumn">
    <Value>Product name</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CustomerShoppingCart.PriceColumn">
    <Value>Unit price</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CustomerShoppingCart.QuantityColumn">
    <Value>Quantity</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CustomerShoppingCart.TotalColumn">
    <Value>Total</Value>
  </LocaleResource>
  <LocaleResource Name="ShoppingCart.Sub-TotalDiscount">
    <Value></Value>
  </LocaleResource>
  <LocaleResource Name="ShoppingCart.OrderDiscount">
    <Value>Discount</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PromotionProviders.Froogle.FTPUpload">
    <Value>Upload feed to Google FTP server</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PromotionProviders.Froogle.FTPHostname.Text">
    <Value>Hostname:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PromotionProviders.Froogle.FTPHostname.Tooltip">
    <Value>Google FTP server hostname</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PromotionProviders.Froogle.FTPUsername.Text">
    <Value>Username:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PromotionProviders.Froogle.FTPUsername.Tooltip">
    <Value>Google FTP account username</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PromotionProviders.Froogle.FTPPassword.Text">
    <Value>Password:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PromotionProviders.Froogle.FTPPassword.Tooltip">
    <Value>Google FTP account password</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PromotionProviders.Froogle.FTPUploadButton">
    <Value>Upload</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PromotionProviders.Froogle.FTPUploadButton.Tooltip">
    <Value>Click here to upload feed</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PromotionProviders.Froogle.FTPUploadStatus">
    <Value>Froogle feed upload status: {0}</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PromotionProviders.Froogle.FTPFilename.Text">
    <Value>File name:</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.PromotionProviders.Froogle.FTPFilename.Tooltip">
    <Value>Feed file name</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CustomerShoppingCart.ShoppingCartColumn">
    <Value>Shopping cart</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SalesHome.CurrentShoppingCarts.TitleDescription">
    <Value>Current Shopping Carts</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SalesHome.CurrentShoppingCarts.Title">
    <Value>Current Shopping Carts</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.SalesHome.CurrentShoppingCarts.Description">
    <Value>Manage current shopping carts</Value>
  </LocaleResource>
  <LocaleResource Name="Admin.CustomerShoppingCart.CustomerColumn.LastAccess">
    <Value>Last access: {0}</Value>
  </LocaleResource>
</Language>
'

CREATE TABLE #LocaleStringResourceTmp
	(
		[LanguageID] [int] NOT NULL,
		[ResourceName] [nvarchar](200) NOT NULL,
		[ResourceValue] [nvarchar](max) NOT NULL
	)


INSERT INTO #LocaleStringResourceTmp (LanguageID, ResourceName, ResourceValue)
SELECT	@resources.value('(/Language/@LanguageID)[1]', 'int'), nref.value('@Name', 'nvarchar(200)'), nref.value('Value[1]', 'nvarchar(MAX)')
FROM	@resources.nodes('//Language/LocaleResource') AS R(nref)

DECLARE @LanguageID int
DECLARE @ResourceName nvarchar(200)
DECLARE @ResourceValue nvarchar(MAX)
DECLARE cur_localeresource CURSOR FOR
SELECT LanguageID, ResourceName, ResourceValue
FROM #LocaleStringResourceTmp
OPEN cur_localeresource
FETCH NEXT FROM cur_localeresource INTO @LanguageID, @ResourceName, @ResourceValue
WHILE @@FETCH_STATUS = 0
BEGIN
	IF (EXISTS (SELECT 1 FROM Nop_LocaleStringResource WHERE LanguageID=@LanguageID AND ResourceName=@ResourceName))
	BEGIN
		UPDATE [Nop_LocaleStringResource]
		SET [ResourceValue]=@ResourceValue
		WHERE LanguageID=@LanguageID AND ResourceName=@ResourceName
	END
	ELSE 
	BEGIN
		INSERT INTO [Nop_LocaleStringResource]
		(
			[LanguageID],
			[ResourceName],
			[ResourceValue]
		)
		VALUES
		(
			@LanguageID,
			@ResourceName,
			@ResourceValue
		)
	END
	
	IF (@ResourceValue is null or @ResourceValue = '')
	BEGIN
		DELETE [Nop_LocaleStringResource]
		WHERE LanguageID=@LanguageID AND ResourceName=@ResourceName
	END
	
	FETCH NEXT FROM cur_localeresource INTO @LanguageID, @ResourceName, @ResourceValue
	END
CLOSE cur_localeresource
DEALLOCATE cur_localeresource

DROP TABLE #LocaleStringResourceTmp
GO



