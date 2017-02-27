﻿using Suucha.WeChat.Core;
using Newtonsoft.Json;

namespace Suucha.WeChat.MessagePlatform.Token
{
    public class AccessTokenResult : WeChatJsonResult
    {

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>
        /// The access token.
        /// </value>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the expires in.
        /// </summary>
        /// <value>
        /// The expires in.
        /// </value>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
