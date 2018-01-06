using Refit;
using Suucha.WeChat.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suucha.WeChat.MessagePlatform.Token.Local
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Suucha.WeChat.MessagePlatform.Token.IMessagePlatformTokenManager" />
    public class MessagePlatformTokenManager : IMessagePlatformTokenManager
    {
        private IMessagePlatformTokenProxy tokenProxy;
        private IMessagePlatformTokenRepository tokenRepository;
        private Dictionary<string, MessagePlatformSetting> settings = new Dictionary<string, MessagePlatformSetting>();

        public MessagePlatformTokenManager(IMessagePlatformTokenRepository tokenRepository)
        {
            this.tokenRepository = tokenRepository;
            tokenProxy = RestService.For<IMessagePlatformTokenProxy>("https://api.weixin.qq.com");
        }
        private async Task<MessagePlatformSetting> GetSettingAsync(string appId)
        {
            MessagePlatformSetting setting;
            if (settings.ContainsKey(appId))
            {
                setting = settings[appId];
            }
            else
            {
                setting = await tokenRepository.GetSettingAsync(appId);
                if(setting != null)
                {
                    settings.Add(appId, setting);
                }
            }
            return setting;
        }
        public string GetAccessToken(string appId, bool forceRefresh = false)
        {
            return GetAccessTokenAsyncInternal(appId, forceRefresh).Result;
        }
        public Task<string> GetAccessTokenAsync(string appId, bool forceRefresh = false)
        {
            return GetAccessTokenAsyncInternal(appId, forceRefresh);
        }
        private async Task<string> GetAccessTokenAsyncInternal(string appId, bool forceRefresh = false)
        {
            var token = await tokenRepository.GetAccessTokenAsync(appId);
            if (token.IsWillExpire() || forceRefresh)
            {
                MessagePlatformSetting setting = await GetSettingAsync(appId);
                token = await GetAndUpdateTokenAsync(appId, setting.AppSecret, setting.AppToken);
            }
            return token.Value;
        }


        public string GetJsApiTicket(string appId, bool forceRefresh = false)
        {
            return GetJsApiTicketAsyncInternal(appId, forceRefresh).Result;
        }
        public Task<string> GetJsApiTicketAsync(string appId, bool forceRefresh = false)
        {
            return GetJsApiTicketAsyncInternal(appId, forceRefresh);
        }
        private async Task<string> GetJsApiTicketAsyncInternal(string appId, bool forceRefresh = false)
        {
            var ticket = await tokenRepository.GetJsApiTicketAsync(appId);
            if (ticket.IsWillExpire() || forceRefresh)
            {
                MessagePlatformSetting setting = await GetSettingAsync(appId);
                ticket = await GetAndUpdateJsApiTicketAsync(appId);
            }
            return ticket.Value;
        }
        private async Task<WillExpireData> GetAndUpdateJsApiTicketAsync(string appId)
        {
            var accessToken = await GetAccessTokenAsync(appId);
            var result = await tokenProxy.GetJsApiTicketAsync(accessToken);
            var jsApiTicket = result.WillExpireData();
            await tokenRepository.SaveJsApiTicketAsync(appId, jsApiTicket);
            return jsApiTicket;
        }
        public void Register(string appId, string appSecret, string appToken, string encodingAesKey)
        {
            RegisterAsyncInternal(appId, appSecret, appToken, encodingAesKey).Wait();
        }
        public Task RegisterAsync(string appId, string appSecret, string appToken, string encodingAesKey)
        {
            return RegisterAsyncInternal(appId, appSecret, appToken, encodingAesKey);
        }
        private async Task RegisterAsyncInternal(string appId, string appSecret, string appToken, string encodingAesKey)
        {
            var setting = await GetSettingAsync(appId);
            if (setting == null)
            {
                setting = new MessagePlatformSetting(appId, appSecret, appToken, encodingAesKey);
                await tokenRepository.SaveSettingAsync(setting);
            }
            else
            {
                setting.AppSecret = appSecret;
                setting.AppToken = appToken;
                setting.EncodingAesKey = encodingAesKey;
                await tokenRepository.UpdateSettingAsync(setting);
            }
        }
        private async Task<WillExpireData> GetAndUpdateTokenAsync(string appId, string secret, string grantType)
        {
            var result = await tokenProxy.GetTokenAsync(appId, secret, grantType);
            tokenRepository.SaveAccessToken(appId, result.WillExpireData());
            return result.WillExpireData();
        }
    }
}
