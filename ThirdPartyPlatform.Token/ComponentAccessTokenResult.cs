using Newtonsoft.Json;
using Suucha.WeChat.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suucha.WeChat.ThirdPartyPlatform.Tokens
{
    public class ComponentAccessTokenResult : WeChatJsonResult
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>
        /// The access token.
        /// </value>
        [JsonProperty("component_access_token")]
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
