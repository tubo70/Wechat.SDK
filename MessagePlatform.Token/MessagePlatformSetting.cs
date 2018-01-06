using Suucha.WeChat.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suucha.WeChat.MessagePlatform.Token
{
    public class MessagePlatformSetting : SettingBase
    {
        public MessagePlatformSetting(string appId, string appSecret, string appToken, string encodingAesKey)
            : base(appId, appSecret, appToken, encodingAesKey)
        {

        }
    }
}
