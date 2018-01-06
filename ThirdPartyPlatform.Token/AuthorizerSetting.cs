using Suucha.WeChat.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suucha.WeChat.ThirdPartyPlatform.Tokens
{
    /// <summary>
    /// 第三方授权设置
    /// </summary>
    public class AuthorizerSetting
    {
        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        /// <value>
        /// The application identifier.
        /// </value>
        public string AppId { get; set; }
        /// <summary>
        /// Gets or sets the refresh token.
        /// </summary>
        /// <value>
        /// The refresh token.
        /// </value>
        public string RefreshToken { get; set; }
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>
        /// The access token.
        /// </value>
        public WillExpireData AccessToken { get; set; }
        /// <summary>
        /// Gets or sets the js API ticket.
        /// </summary>
        /// <value>
        /// The js API ticket.
        /// </value>
        public WillExpireData JsApiTicket { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizerSetting"/> class.
        /// </summary>
        public AuthorizerSetting()
        {
            AccessToken = new WillExpireData();
            JsApiTicket = new WillExpireData();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizerSetting"/> class.
        /// </summary>
        /// <param name="appId">The application identifier.</param>
        /// <param name="refreshToken">The refresh token.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="jsApiTicket">The js API ticket.</param>
        public AuthorizerSetting(string appId, string refreshToken,
            WillExpireData accessToken, WillExpireData jsApiTicket)
            : base()
        {
            AppId = appId;
            RefreshToken = refreshToken;
            if(accessToken != null)
            {
                AccessToken = accessToken;
            }
            if(jsApiTicket != null)
            {
                JsApiTicket = jsApiTicket;
            }
        }
    }
}
