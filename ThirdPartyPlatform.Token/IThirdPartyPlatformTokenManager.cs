using System;
using System.Collections.Generic;
using System.Text;

namespace Suucha.WeChat.ThirdPartyPlatform.Tokens
{
    /// <summary>
    /// 
    /// </summary>
    public interface IThirdPartyPlatformTokenManager
    {
        /// <summary>
        /// Registers the specified component application identifier.
        /// </summary>
        /// <param name="componentAppId">The component application identifier.</param>
        /// <param name="appSecret">The application secret.</param>
        /// <param name="appToken">The application token.</param>
        /// <param name="encodingAesKey">The encoding aes key.</param>
        void Register(string componentAppId, string appSecret, string appToken, string encodingAesKey);
        //void Register(string componentAppId, string appSecret, string appToken, string encodingAesKey, IThirdPartyPlatformSettingRepository callback);
        /// <summary>
        /// Gets the third party platform setting.
        /// </summary>
        /// <param name="componentAppId">The component application identifier.</param>
        /// <returns></returns>
        ThirdPartyPlatformSetting GetThirdPartyPlatformSetting(string componentAppId);
        /// <summary>
        /// Gets the access token.
        /// </summary>
        /// <param name="componentAppId">The component application identifier.</param>
        /// <param name="forceRefresh">if set to <c>true</c> [force refresh].</param>
        /// <returns></returns>
        string GetAccessToken(string componentAppId, bool forceRefresh = false);
        /// <summary>
        /// Creates the pre authentication code.
        /// </summary>
        /// <param name="componentAppId">The component application identifier.</param>
        /// <returns></returns>
        string CreatePreAuthCode(string componentAppId);
        /// <summary>
        /// Queries the authentication.
        /// </summary>
        /// <param name="componentAppId">The component application identifier.</param>
        /// <param name="authCode">The authentication code.</param>
        void QueryAuth(string componentAppId, string authCode);
        /// <summary>
        /// Gets the authorizer access token.
        /// </summary>
        /// <param name="componentAppId">The component application identifier.</param>
        /// <param name="authorizerAppId">The authorizer application identifier.</param>
        /// <param name="forceRefresh">if set to <c>true</c> [force refresh].</param>
        /// <returns></returns>
        string GetAuthorizerAccessToken(string componentAppId, string authorizerAppId, bool forceRefresh = false);
        /// <summary>
        /// Gets the authorizer js API ticket.
        /// </summary>
        /// <param name="componentAppId">The component application identifier.</param>
        /// <param name="authorizerAppId">The authorizer application identifier.</param>
        /// <param name="forceRefresh">if set to <c>true</c> [force refresh].</param>
        /// <returns></returns>
        string GetAuthorizerJsApiTicket(string componentAppId, string authorizerAppId, bool forceRefresh = false);
        /// <summary>
        /// Verifies the specified XML message.
        /// </summary>
        /// <param name="xmlMessage">The XML message.</param>
        /// <param name="messageSignature">The message signature.</param>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="nonce">The nonce.</param>
        /// <returns></returns>
        bool Verify(string xmlMessage, string messageSignature, string timestamp, string nonce);
    }
}
