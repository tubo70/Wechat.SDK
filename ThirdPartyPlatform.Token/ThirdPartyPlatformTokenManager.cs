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
            throw new NotImplementedException();

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
