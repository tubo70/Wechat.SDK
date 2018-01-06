using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="encodingAesKey">公众号应用encodingAseKey</param>
        void Register(string appId, string appSecret, string appToken, string encodingAesKey);
        /// <summary>
        /// Registers the asynchronous.
        /// </summary>
        /// <param name="appId">The application identifier.</param>
        /// <param name="appSecret">The application secret.</param>
        /// <param name="appToken">The application token.</param>
        /// <param name="encodingAesKey">The encoding aes key.</param>
        /// <returns></returns>
        Task RegisterAsync(string appId, string appSecret, string appToken, string encodingAesKey);
        /// <summary>
        /// Gets the access token.
        /// </summary>
        /// <param name="appId">The application identifier.</param>
        /// <param name="forceRefresh">if set to <c>true</c> [force refresh].</param>
        /// <returns></returns>
        string GetAccessToken(string appId, bool forceRefresh = false);
        /// <summary>
        /// 根据公众号应用ID获取访问令牌
        /// </summary>
        /// <param name="appId">公众号应用ID</param>
        /// <param name="forceRefresh">是否强制刷新</param>
        /// <returns>访问令牌</returns>
        Task<string> GetAccessTokenAsync(string appId, bool forceRefresh = false);
        /// <summary>
        /// 根据公众号应用ID获取JS API票据
        /// </summary>
        /// <param name="appId">公众号应用ID</param>
        /// <param name="forceRefresh">是否强制刷新</param>
        /// <returns>JS API票据</returns>
        string GetJsApiTicket(string appId, bool forceRefresh = false);
        /// <summary>
        /// 异步根据公众号应用ID获取JS API票据
        /// </summary>
        /// <param name="appId">公众号应用ID</param>
        /// <param name="forceRefresh">是否强制刷新</param>
        /// <returns>JS API票据</returns>
        Task<string> GetJsApiTicketAsync(string appId, bool forceRefresh = false);

    }
}
