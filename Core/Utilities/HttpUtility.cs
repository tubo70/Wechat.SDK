using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Suucha.WeChat.Core.Utilities
{
    public class HttpUtility
    {
        ILogger Logger { get; } = ApplicationLogging.CreateLogger<HttpUtility>();
        private static HttpClient httpClient;
        static HttpUtility()
        {
            httpClient = new HttpClient();
        }
        private static string BuildUrl(string url, Dictionary<string, object> @params)
        {
            string newUrl = url;
            int position = newUrl.IndexOf("?");
            string connector = "?";
            if (position >= 1)
            {
                connector = "&";
            }
            foreach (KeyValuePair<string, object> keyValue in @params)
            {
                newUrl = newUrl + connector + keyValue.Key + "=" + WebUtility.UrlEncode(keyValue.Value.ToString());
                connector = "&";
            }
            return newUrl;
        }
        private static async Task<string> Execute(HttpRequestMessage requestMessage)
        {
            var response = await httpClient.SendAsync(requestMessage);
            return await response.Content.ReadAsStringAsync();
        }
        public static Task<string> GetStringAsync(string url)
        {
            return httpClient.GetStringAsync(url);
        }
        public static Task<string> GetStringAsync(string url, Dictionary<string, object> @params)
        {
            string urlWithParams = BuildUrl(url, @params);
            return GetStringAsync(urlWithParams);
        }
        public static async Task<T> GetJsonAsync<T>(string url)
        {
            string result = await GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(result);
        }
        public static Task<T> GetJsonAsync<T>(string url, Dictionary<string, object> @params)
        {
            string urlWithParams = BuildUrl(url, @params);
            return GetJsonAsync<T>(urlWithParams);
        }
        public static Task<string> PostWithBody(string url, string body, Dictionary<string, object> headers = null, Encoding encoding = null)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            if (headers != null)
            {
                foreach(var keyValue in  headers)
                {
                    requestMessage.Headers.Add(keyValue.Key, keyValue.Value.ToString());
                }
            }
            if (!string.IsNullOrEmpty(body))
            {
                if(encoding == null)
                {
                    encoding = Encoding.UTF8;
                }
                StringContent content = new StringContent(body, encoding);
                requestMessage.Content = content;
            }
            return Execute(requestMessage);
        }
        public static Task<string> Post(string url,  Encoding encoding = null)
        {
            return PostWithBody(url, "", null, encoding);
        }
        public static Task<string> PostWithHeaders(string url, Dictionary<string, object> headers = null, Encoding encoding = null)
        {
            return PostWithBody(url, "", headers, encoding);
        }
        public static Task<string> Post(string url, Dictionary<string, object> @params, Encoding encoding = null)
        {
            string urlWithParams = url;
            if(@params != null)
            {
                urlWithParams = BuildUrl(url, @params);
            }
            return PostWithBody(url, "", null, encoding);
        }
        public static Task<string> PostWithHeaders(string url, Dictionary<string, object> @params, Dictionary<string, object> headers = null, Encoding encoding = null)
        {
            string urlWithParams = url;
            if (@params != null)
            {
                urlWithParams = BuildUrl(url, @params);
            }
            return PostWithBody(url, "", headers, encoding);
        }
    }
}
