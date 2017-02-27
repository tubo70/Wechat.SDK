using Tencent;

namespace Suucha.WeChat.Core.Utilities
{
    public class CryptologyUtility
    {
        /// <summary>
        /// Decrypts the message.
        /// </summary>
        /// <param name="componentAppId">The component application identifier.</param>
        /// <param name="appToken">The application token.</param>
        /// <param name="encodingAesKey">The encoding aes key.</param>
        /// <param name="xmlMessage">The XML message.</param>
        /// <param name="messageSignature">The message signature.</param>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="nonce">The nonce.</param>
        /// <returns></returns>
        public static string DecryptMessage(string componentAppId, string appToken, string encodingAesKey, string xmlMessage, string messageSignature, string timestamp, string nonce)
        {
            var result = "";
            WXBizMsgCrypt wxBizMsgCrypt = new WXBizMsgCrypt(appToken, encodingAesKey, componentAppId);
            var ret = wxBizMsgCrypt.DecryptMsg(messageSignature, timestamp, nonce, xmlMessage, ref result);
            return result;
        }
        /// <summary>
        /// Encrypts the message.
        /// </summary>
        /// <param name="componentAppId">The component application identifier.</param>
        /// <param name="appToken">The application token.</param>
        /// <param name="encodingAesKey">The encoding aes key.</param>
        /// <param name="xmlMessage">The XML message.</param>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="nonce">The nonce.</param>
        /// <returns></returns>
        public static string EncryptMessage(string componentAppId, string appToken, string encodingAesKey, string xmlMessage, string timestamp, string nonce)
        {
            var result = "";
            WXBizMsgCrypt wxBizMsgCrypt = new WXBizMsgCrypt(appToken, encodingAesKey, componentAppId);
            var ret = wxBizMsgCrypt.EncryptMsg(xmlMessage, timestamp, nonce, ref result);
            return result;
        }
    }
}
