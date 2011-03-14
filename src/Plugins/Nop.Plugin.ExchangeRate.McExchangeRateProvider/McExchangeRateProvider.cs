﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Xml;
using Nop.Core.Plugins;
using Nop.Services.Directory;
using Nop.Core.Domain.Directory;

namespace Nop.Plugin.ExchangeRate.McExchange
{
    public class McExchangeRateProvider : IExchangeRateProvider
    {
        #region Methods

        /// <summary>
        /// Gets currency live rates
        /// </summary>
        /// <param name="exchangeRateCurrencyCode">Exchange rate currency code</param>
        /// <returns>Exchange rates</returns>
        public List<Nop.Core.Domain.Directory.ExchangeRate> GetCurrencyLiveRates(string exchangeRateCurrencyCode)
        {
            var exchangeRates = new List<Nop.Core.Domain.Directory.ExchangeRate>();
            string url = string.Format("http://themoneyconverter.com/{0}/rss.xml", exchangeRateCurrencyCode);

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            using (WebResponse response = request.GetResponse())
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
                nsmgr.AddNamespace("atom", "http://www.w3.org/2005/Atom");
                nsmgr.AddNamespace("cf", "http://www.microsoft.com/schemas/rss/core/2005");
                nsmgr.AddNamespace("cfi", "http://www.microsoft.com/schemas/rss/core/2005/internal");

                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ".";
                provider.NumberGroupSeparator = "";

                foreach (XmlNode node in xmlDoc.DocumentElement.FirstChild.ChildNodes)
                {
                    if (node.Name == "item")
                    {
                        /*
                                <item>
                                  <title xmlns:cf="http://www.microsoft.com/schemas/rss/core/2005" cf:type="text">AED/NZD</title>
                                  <link>http://themoneyconverter.com/NZD/AED.aspx</link>
                                  <guid>http://themoneyconverter.com/NZD/AED.aspx</guid>
                                  <pubDate>Fri, 20 Feb 2009 08:01:41 GMT</pubDate>
                                  <atom:published xmlns:atom="http://www.w3.org/2005/Atom">2009-02-20T08:01:41Z</atom:published>
                                  <atom:updated xmlns:atom="http://www.w3.org/2005/Atom">2009-02-20T08:01:41Z</atom:updated>
                                  <description xmlns:cf="http://www.microsoft.com/schemas/rss/core/2005" cf:type="html">1 New Zealand Dollar = 1.84499 Arab Emirates Dirham</description>
                                  <category>Middle-East</category>
                                  <cfi:id>32</cfi:id>
                                  <cfi:effectiveId>1074571199</cfi:effectiveId>
                                  <cfi:read>true</cfi:read>
                                  <cfi:downloadurl>http://themoneyconverter.com/NZD/rss.xml</cfi:downloadurl>
                                  <cfi:lastdownloadtime>2009-02-20T08:05:27.168Z</cfi:lastdownloadtime>
                                </item>
                        */
                        Nop.Core.Domain.Directory.ExchangeRate rate = new Nop.Core.Domain.Directory.ExchangeRate();
                        foreach (XmlNode detailNode in node.ChildNodes)
                        {
                            switch (detailNode.Name)
                            {
                                case "title":
                                    rate.CurrencyCode = detailNode.InnerText.Substring(0, 3);
                                    break;

                                case "pubDate":
                                    rate.UpdatedOn = DateTime.Parse(detailNode.InnerText);
                                    break;

                                case "description":
                                    string description = detailNode.InnerText;
                                    int x = description.IndexOf('=');
                                    int y = description.IndexOf(' ', x + 2);

                                    //          1         2         3         4
                                    //01234567890123456789012345678901234567890
                                    // 1 New Zealand Dollar = 0.78815 Australian Dollar
                                    // x = 21
                                    // y = 30
                                    string rateText = description.Substring(x + 1, y - x - 1).Trim();
                                    rate.Rate = decimal.Parse(rateText, provider);
                                    break;

                                default:
                                    break;
                            }

                        }

                        // Update the Rate in the collection if its already in there
                        if (rate.CurrencyCode != null)
                        {
                            exchangeRates.Add(rate);
                        }
                    } // if node is an item
                } // foreach child node under <channel>
            }

            return exchangeRates;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the friendly name
        /// </summary>
        public string FriendlyName
        {
            get
            {
                //TODO localize
                return "Money converter exchange rate provider";
            }
        }

        /// <summary>
        /// Gets or sets the system name
        /// </summary>
        public string SystemName
        {
            get
            {
                return "MoneyConverter";
            }
        }
        #endregion

        #region IPlugin Members

        public string Name
        {
            get { return FriendlyName; }
        }

        public int SortOrder
        {
            get { return 1; }
        }

        public bool IsAuthorized(IPrincipal user)
        {
            return true;
        }

        public int CompareTo(IPlugin other)
        {
            return SortOrder - other.SortOrder;
        }
        #endregion
    }
}
