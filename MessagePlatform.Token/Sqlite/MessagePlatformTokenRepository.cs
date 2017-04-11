using System;
using System.Collections.Generic;
using System.Text;
using Suucha.WeChat.Core;

namespace Suucha.WeChat.MessagePlatform.Token.Sqlite
{
    public class MessagePlatformTokenRepository : IMessagePlatformTokenRepository
    {
        public WillExpireData GetAccessToken(string appId)
        {
            throw new NotImplementedException();
        }

        public WillExpireData GetJsApiTicket(string appId)
        {
            throw new NotImplementedException();
        }

        public void SaveAccessToken(string appId, WillExpireData accessToken)
        {
            throw new NotImplementedException();
        }

        public void SaveJsApiTicket(string appId, WillExpireData ticket)
        {
            throw new NotImplementedException();
        }
    }
}
