﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suucha.WeChat.Core.Configurations
{
    public class WeChatConfiguration
    {
        public string AppId { get; set; }
        public string AppToken { get; set; }
        public string EncodingAesKey { get; set; }
        public string AppSecret { get; set; }
    }
}
