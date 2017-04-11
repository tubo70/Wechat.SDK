using Suucha.WeChat.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suucha.WeChat.MessagePlatform.Token
{
    public interface IMessagePlatformTokenRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="accessToken"></param>
        void SaveAccessToken(String appId, WillExpireData accessToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="ticket"></param>
        void SaveJsApiTicket(String appId, WillExpireData ticket);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        WillExpireData GetAccessToken(String appId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        WillExpireData GetJsApiTicket(String appId);
    }
}
