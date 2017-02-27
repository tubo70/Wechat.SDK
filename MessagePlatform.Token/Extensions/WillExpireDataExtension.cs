using Suucha.WeChat.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suucha.WeChat.MessagePlatform.Token
{
    public static class WillExpireDataExtension
    {
        public static WillExpireData WillExpireData(this AccessTokenResult result)
        {
            if (!string.IsNullOrEmpty(result.AccessToken) && result.ExpiresIn > 0)
            {
                return new WillExpireData(result.AccessToken, result.ExpiresIn);
            }
            return new WillExpireData();
        }

        public static WillExpireData WillExpireData(this JsApiTicketResult result)
        {
            if (!string.IsNullOrEmpty(result.Ticket) && result.ExpiresIn > 0)
            {
                return new WillExpireData(result.Ticket, result.ExpiresIn);
            }
            return new WillExpireData();
        }
    }
}
