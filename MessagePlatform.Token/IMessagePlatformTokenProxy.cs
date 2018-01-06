using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Suucha.WeChat.MessagePlatform.Token
{
    public interface IMessagePlatformTokenProxy
    {
        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <param name="appId">The application identifier.</param>
        /// <param name="secret">The secret.</param>
        /// <param name="grantType">Type of the grant.</param>
        /// <returns></returns>
        [Get("/cgi-bin/token")] //grant_type=%s&appid=%s&secret=%s
        Task<AccessTokenResult> GetTokenAsync([AliasAs("appid")]string appId,
            string secret,
            [AliasAs("grant_type")]string grantType = "client_credential");
        
        /// <summary>
        /// 访问接口：
        /// https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=ACCESS_TOKEN&type=jsapi
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [Get("/cgi-bin/ticket/getticket")]
        Task<JsApiTicketResult> GetJsApiTicketAsync([AliasAs("access_token")] string accessToken, string type="jsapi");
    }
}
