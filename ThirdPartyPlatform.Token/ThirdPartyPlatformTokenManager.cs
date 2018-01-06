using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Suucha.WeChat.ThirdPartyPlatform.Tokens
{
    public class ThirdPartyPlatformTokenManager : IThirdPartyPlatformTokenManager
    {
        private static readonly HttpClient client = new HttpClient();
        private static Dictionary<string, ThirdPartyPlatformSetting> settings = new Dictionary<string, ThirdPartyPlatformSetting>();
        private string RefreshAccessToken(string componentAppId)
        {
            if (!settings.ContainsKey(componentAppId))
            {
                throw new InvalidOperationException("请先注册app");
            }

        }
        private async ComponentAccessTokenResult GetToken(string componentAppId, string secret, string ticket)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/component/api_component_token";
            Dictionary<String, Object> data = new Dictionary<string, object>
            {
                { "component_appid", componentAppId },
                { "component_appsecret", secret },
                { "component_verify_ticket", ticket }
            };
            ComponentAccessTokenResult result = null;
            HttpContent content = new HttpContent();
            result = await client.PostAsync(url, content);//.postWithBodyResultByJson(ComponentAccessTokenResult.class, url, JSON.toJSONString(data));

            checkResult(result);
            return result;
        }
        public string CreatePreAuthCode(string componentAppId)
        {

            throw new NotImplementedException();
        }

        public string GetAccessToken(string componentAppId, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public string GetAuthorizerAccessToken(string componentAppId, string authorizerAppId, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public string GetAuthorizerJsApiTicket(string componentAppId, string authorizerAppId, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public ThirdPartyPlatformSetting GetThirdPartyPlatformSetting(string componentAppId)
        {
            throw new NotImplementedException();
        }

        public void QueryAuth(string componentAppId, string authCode)
        {
            throw new NotImplementedException();
        }

        public void Register(string componentAppId, string appSecret, string appToken, string encodingAesKey)
        {
            throw new NotImplementedException();
        }

        public bool Verify(string xmlMessage, string messageSignature, string timestamp, string nonce)
        {
            throw new NotImplementedException();
        }
    }
}
