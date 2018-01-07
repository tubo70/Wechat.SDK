using Suucha.WeChat.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suucha.WeChat.MessagePlatform.Token
{
    public class MessagePlatformSetting : SettingBase
    {
        /// <summary>
        /// Gets or sets the js API ticket.
        /// </summary>
        /// <value>
        /// The js API ticket.
        /// </value>
        public WillExpireData JsApiTicket { get; set; }
        public MessagePlatformSetting(string appId, string appSecret, string appToken, string encodingAesKey)
            : base(appId, appSecret, appToken, encodingAesKey)
        {

        }
    }
}
