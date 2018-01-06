using Suucha.WeChat.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Suucha.WeChat.MessagePlatform.Token
{
    public interface IMessagePlatformTokenRepository
    {
        /// <summary>
        /// Adds the setting.
        /// </summary>
        /// <param name="setting">The setting.</param>
        void SaveSetting(MessagePlatformSetting setting);
        /// <summary>
        /// Adds the setting asynchronous.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <returns></returns>
        Task SaveSettingAsync(MessagePlatformSetting setting);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="accessToken"></param>
        void SaveAccessToken(string appId, WillExpireData accessToken);
        /// <summary>
        /// Saves the access token asynchronous.
        /// </summary>
        /// <param name="appId">The application identifier.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns></returns>
        Task SaveAccessTokenAsync(string appId, WillExpireData accessToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="ticket"></param>
        void SaveJsApiTicket(string appId, WillExpireData ticket);
        /// <summary>
        /// Saves the js API ticket asynchronous.
        /// </summary>
        /// <param name="appId">The application identifier.</param>
        /// <param name="ticket">The ticket.</param>
        /// <returns></returns>
        Task SaveJsApiTicketAsync(string appId, WillExpireData ticket);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        WillExpireData GetAccessToken(string appId);
        /// <summary>
        /// Gets the access token asynchronous.
        /// </summary>
        /// <param name="appId">The application identifier.</param>
        /// <returns></returns>
        Task<WillExpireData> GetAccessTokenAsync(string appId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        WillExpireData GetJsApiTicket(string appId);
        /// <summary>
        /// Gets the js API ticket asynchronous.
        /// </summary>
        /// <param name="appId">The application identifier.</param>
        /// <returns></returns>
        Task<WillExpireData> GetJsApiTicketAsync(string appId);
        /// <summary>
        /// Gets the specified application identifier.
        /// </summary>
        /// <param name="appId">The application identifier.</param>
        /// <returns></returns>
        MessagePlatformSetting GetSetting(string appId);
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="appId">The application identifier.</param>
        /// <returns></returns>
        Task<MessagePlatformSetting> GetSettingAsync(string appId);
    }
}
