using Suucha.WeChat.Core;
using System;
using System.Collections.Generic;

namespace Suucha.WeChat.ThirdPartyPlatform.Tokens
{
    public class ThirdPartyPlatformSetting : SettingBase
    {

        /// <summary>
        /// Gets or sets the verify ticket.
        /// </summary>
        /// <value>
        /// The verify ticket.
        /// </value>
        public WillExpireData VerifyTicket { get; set; }
        /// <summary>
        /// Gets or sets the authorizer settings.
        /// </summary>
        /// <value>
        /// The authorizer settings.
        /// </value>
        public Dictionary<string, AuthorizerSetting> AuthorizerSettings { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThirdPartyPlatformSetting"/> class.
        /// </summary>
        /// <param name="appId">The application identifier.</param>
        /// <param name="appSecret">The application secret.</param>
        /// <param name="appToken">The application token.</param>
        /// <param name="encodingAesKey">The encoding aes key.</param>
        public ThirdPartyPlatformSetting(string appId, string appSecret, string appToken, string encodingAesKey)
            : base(appId, appSecret, appToken, encodingAesKey)
        {
            VerifyTicket = new WillExpireData();
            AuthorizerSettings = new Dictionary<string, AuthorizerSetting>();
        }

        /// <summary>
        /// Gets the authorizer access token.
        /// </summary>
        /// <param name="authorizerAppId">The authorizer application identifier.</param>
        /// <returns></returns>
        public AuthorizerSetting GetAuthorizerAccessToken(string authorizerAppId)
        {
            if (AuthorizerSettings.ContainsKey(authorizerAppId))
            {
                return AuthorizerSettings[authorizerAppId];
            }
            return null;
        }
        /// <summary>
        /// Adds the authorizer setting.
        /// </summary>
        /// <param name="authorizerAppId">The authorizer application identifier.</param>
        /// <param name="refreshToken">The refresh token.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="jsApiTicket">The js API ticket.</param>
        public void AddAuthorizerSetting(string authorizerAppId, string refreshToken,
            WillExpireData accessToken, WillExpireData jsApiTicket)
        {
            AuthorizerSetting authorizerSetting = new AuthorizerSetting(authorizerAppId, refreshToken,
                accessToken, jsApiTicket);
            if (AuthorizerSettings.ContainsKey(authorizerAppId))
            {
                AuthorizerSettings.Remove(authorizerAppId);
            }
            AuthorizerSettings.Add(authorizerAppId, authorizerSetting);
        }
    }
}
