
using System;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Payments;

namespace Nop.Services.Common
{
    public static class LiveChatExtentions
    {
        public static bool IsLiveChatProviderActive(this ILiveChatProvider liveChatProvider,
            LiveChatSettings liveChatSettings)
        {
            if (liveChatProvider == null)
                throw new ArgumentNullException("liveChatProvider");

            if (liveChatSettings == null)
                throw new ArgumentNullException("liveChatSettings");

            if (liveChatSettings.ActiveLiveChatProviderSystemName == null)
                return false;
            foreach (string activeProviderSystemName in liveChatSettings.ActiveLiveChatProviderSystemName)
                if (liveChatProvider.SystemName.Equals(activeProviderSystemName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            return false;
        }
    }
}
