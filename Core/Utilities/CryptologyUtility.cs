using Tencent;

namespace Suucha.WeChat.Core.Utilities
{
    public class CryptologyUtility
    {
        
        public static string DecryptMessage(string appId, string appToken, string encodingAesKey, string xmlMessage, string messageSignature, string timestamp, string nonce)
        {
            var result = "";
            WXBizMsgCrypt wxBizMsgCrypt = new WXBizMsgCrypt(appToken, encodingAesKey, appId);
            var ret = wxBizMsgCrypt.DecryptMsg(messageSignature, timestamp, nonce, xmlMessage, ref result);
            return result;
        }
        /// <summary>
        /// Encrypts the message.
        /// </summary>
        /// <param name="appId">The component application identifier.</param>
        /// <param name="appToken">The application token.</param>
        /// <param name="encodingAesKey">The encoding aes key.</param>
        /// <param name="xmlMessage">The XML message.</param>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="nonce">The nonce.</param>
        /// <returns></returns>
        public static string EncryptMessage(string appId, string appToken, string encodingAesKey, string xmlMessage, string timestamp, string nonce)
        {
            var result = "";
            WXBizMsgCrypt wxBizMsgCrypt = new WXBizMsgCrypt(appToken, encodingAesKey, appId);
            var ret = wxBizMsgCrypt.EncryptMsg(xmlMessage, timestamp, nonce, ref result);
            return result;
        }
    }
}
