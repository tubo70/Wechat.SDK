using Suucha.WeChat.Core;
using Newtonsoft.Json;
namespace Suucha.WeChat.MessagePlatform.Token
{
    public class JsApiTicketResult : WeChatJsonResult
    {
        /// <summary>
        /// Gets or sets the ticket.
        /// </summary>
        /// <value>
        /// The ticket.
        /// </value>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }
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
