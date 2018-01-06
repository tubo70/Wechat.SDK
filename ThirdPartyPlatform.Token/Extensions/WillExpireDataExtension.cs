using Suucha.WeChat.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suucha.WeChat.ThirdPartyPlatform.Tokens
{
    public static class WillExpireDataExtension
    {
        public static WillExpireData WillExpireData(this ComponentAccessTokenResult result)
        {
            if (!string.IsNullOrEmpty(result.AccessToken) && result.ExpiresIn > 0)
            {
                return new WillExpireData(result.AccessToken, result.ExpiresIn);
            }
            return new WillExpireData();
        }
    }
}
