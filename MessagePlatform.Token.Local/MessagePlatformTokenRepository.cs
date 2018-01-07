using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Suucha.WeChat.Core;
using Microsoft.Data.Sqlite;
using System.Data.Common;
using Newtonsoft.Json;

namespace Suucha.WeChat.MessagePlatform.Token.Local
{
    public class MessagePlatformTokenRepository : IMessagePlatformTokenRepository
    {
        private IDatabase database;
        public MessagePlatformTokenRepository(IDatabase database)
        {
            this.database = database;
        }
        public WillExpireData GetAccessToken(string appId)
        {
            throw new NotImplementedException();
        }

        public Task<WillExpireData> GetAccessTokenAsync(string appId)
        {
            throw new NotImplementedException();
        }

        public WillExpireData GetJsApiTicket(string appId)
        {
            throw new NotImplementedException();
        }

        public Task<WillExpireData> GetJsApiTicketAsync(string appId)
        {
            throw new NotImplementedException();
        }

        public MessagePlatformSetting GetSetting(string appId)
        {
            return GetSettingAsyncInternal(appId).Result;
        }

        public Task<MessagePlatformSetting> GetSettingAsync(string appId)
        {
            return GetSettingAsyncInternal(appId);
        }
        private async Task<MessagePlatformSetting> GetSettingAsyncInternal(string appId)
        {
            MessagePlatformSetting setting = null;
            using(var connection = database.GetConnection())
            {
                connection.Open();
                var sql = "Select * From message_platform Where app_id='" + appId + "'";
                var command = connection.CreateCommand();
                command.CommandText = sql;
                var reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    setting = Map(reader);
                    break;
                }
                reader.Close();
                connection.Close();
            }
            return setting;
        }

        public void SaveAccessToken(string appId, WillExpireData accessToken)
        {
            SaveAccessTokenAsyncInternal(appId, accessToken).Wait();
        }

        public Task SaveAccessTokenAsync(string appId, WillExpireData accessToken)
        {
            return SaveAccessTokenAsyncInternal(appId, accessToken);
        }
        private async Task SaveAccessTokenAsyncInternal(string appId, WillExpireData accessToken)
        {
            using(var connection = database.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "Update message_platform Set access_token = @accessToken Where app_id=@appId";
                command.Parameters.Add(JsonConvert.SerializeObject(accessToken));
                command.Parameters.Add(appId);
                await command.ExecuteNonQueryAsync();
            }
        }
        public void SaveJsApiTicket(string appId, WillExpireData ticket)
        {
            SaveJsApiTicketAsyncInternal(appId, ticket).Wait();
        }

        public Task SaveJsApiTicketAsync(string appId, WillExpireData ticket)
        {
            return SaveJsApiTicketAsyncInternal(appId, ticket);
        }
        private async Task SaveJsApiTicketAsyncInternal(string appId, WillExpireData ticket)
        {
            using (var connection = database.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "Update message_platform Set js_api_ticket = @jsApiTicket Where app_id=@appId";
                command.Parameters.Add(JsonConvert.SerializeObject(ticket));
                command.Parameters.Add(appId);
                await command.ExecuteNonQueryAsync();
            }
        }
        public void SaveSetting(MessagePlatformSetting setting)
        {
            SaveSettingAsyncInternal(setting).Wait();
        }

        public Task SaveSettingAsync(MessagePlatformSetting setting)
        {
            return SaveSettingAsyncInternal(setting);
        }
        private async Task SaveSettingAsyncInternal(MessagePlatformSetting setting)
        {
            using (var connection = database.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                var sql = @"Update message_platform Set 
                            app_secret=@appSecret, 
                            app_token=@appToken,
                            encoding_aes_key=@encodingAesKey
                            Where app_id=@appId";
                command.CommandText = sql;
                command.Parameters.Add(setting.AppSecret);
                command.Parameters.Add(setting.AppToken);
                command.Parameters.Add(setting.EncodingAesKey);
                command.Parameters.Add(setting.AppId);
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }
        private MessagePlatformSetting Map(DbDataReader reader)
        {
            MessagePlatformSetting setting = new MessagePlatformSetting(
                (string)reader["app_id"],
                (string)reader["app_secret"],
                (string)reader["app_token"],
                (string)reader["encoding_aes_key"]);
            string accessToken = (string)reader["access_token"];
            string jsApiTicket = (string)reader["js_api_ticket"];
            setting.AccessToken = JsonConvert.DeserializeObject<WillExpireData>(accessToken);
            setting.JsApiTicket = JsonConvert.DeserializeObject<WillExpireData>(jsApiTicket);
            return setting;
        }
    }


}
