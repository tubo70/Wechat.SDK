using System;
using System.Collections.Generic;
using System.Text;

namespace Suucha.WeChat.Core
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SettingBase
    {
        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        /// <value>
        /// The application identifier.
        /// </value>
        public string AppId { get; set; }
        /// <summary>
        /// Gets or sets the application secret.
        /// </summary>
        /// <value>
        /// The application secret.
        /// </value>
        public string AppSecret { get; set; }
        /// <summary>
        /// Gets or sets the application token.
        /// </summary>
        /// <value>
        /// The application token.
        /// </value>
        public string AppToken { get; set; }
        /// <summary>
        /// Gets or sets the encoding aes key.
        /// </summary>
        /// <value>
        /// The encoding aes key.
        /// </value>
        public string EncodingAesKey { get; set; }
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>
        /// The access token.
        /// </value>
        public WillExpireData AccessToken { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingBase"/> class.
        /// </summary>
        /// <param name="appId">The application identifier.</param>
        /// <param name="appsecret">The appsecret.</param>
        /// <param name="appToken">The application token.</param>
        public SettingBase(string appId, string appSecret, string appToken, string encodingAesKey)
        {
            AppId = appId;
            AppSecret = appSecret;
            AppToken = appToken;
            EncodingAesKey = encodingAesKey;
            AccessToken = new WillExpireData();
        }
    }
}
