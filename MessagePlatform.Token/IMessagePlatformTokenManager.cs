using System;
using System.Collections.Generic;
using System.Text;

namespace Suucha.WeChat.MessagePlatform.Token
{
    public interface IMessagePlatformTokenManager
    {
        /// <summary>
        /// 注册公众号
        /// </summary>
        /// <param name="appId">公众号应用ID</param>
        /// <param name="appSecret">公众号应用密钥</param>
        /// <param name="appToken">公众号应用Token</param>
        void Register(string appId, string appSecret, string appToken);

        /// <summary>
        /// 根据公众号应用ID获取访问令牌
        /// </summary>
        /// <param name="appId">公众号应用ID</param>
        /// <returns>访问令牌</returns>
        string GetAccessToken(string appId);

        /// <summary>
        /// 根据公众号应用ID获取访问令牌(强制刷新令牌)
        /// </summary>
        /// <param name="appId">公众号应用ID</param>
        /// <returns>访问令牌</returns>
        string GetAccessTokenByRefresh(string appId);

        /// <summary>
        /// 根据公众号应用ID获取JS API票据
        /// </summary>
        /// <param name="appId">公众号应用ID</param>
        /// <returns>JS API票据</returns>
        string GetJsApiTicket(string appId);

        /// <summary>
        /// 根据公众号应用ID获取JS API票据（强制刷新）
        /// </summary>
        /// <param name="appId">公众号应用ID</param>
        /// <returns>JS API票据</returns>
        string GetJsApiTicketByRefresh(string appId);
    }
}
