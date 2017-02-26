using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suucha.WeChat.Core
{
    public class WeChatJsonResult
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>
        /// The error code.
        /// </value>
        [JsonProperty("errcode")]
        public int? ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        [JsonProperty("errmsg")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Determines whether this instance is success.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </returns>
        public bool IsSuccess()
        {
            if (ErrorCode == null || ErrorCode == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (IsSuccess())
            {
                return base.ToString();
            }
            return string.Format("Error code:{0}, Error message:{1}", ErrorCode, ErrorMessage);
        }
    }
}
