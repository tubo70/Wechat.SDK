using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Suucha.WeChat.Core;
using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace Suucha.WeChat.MessagePlatform.Token.Local.Sqlite
{
    public class MessagePlatformTokenRepository : IMessagePlatformTokenRepository
    {
        IDatabase database;

        public MessagePlatformTokenRepository(IDatabase database)
        {
            this.database = database;
            if (database != null)
            {
                database.CreateDatabaseNecessary();
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
                DbCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "";
                var count = await command.ExecuteNonQueryAsync();
            }
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
            throw new NotImplementedException();
        }

        public Task<MessagePlatformSetting> GetSettingAsync(string appId)
        {
            throw new NotImplementedException();
        }

        public void SaveAccessToken(string appId, WillExpireData accessToken)
        {
            throw new NotImplementedException();
        }

        public Task SaveAccessTokenAsync(string appId, WillExpireData accessToken)
        {
            throw new NotImplementedException();
        }

        public void SaveJsApiTicket(string appId, WillExpireData ticket)
        {
            throw new NotImplementedException();
        }

        public Task SaveJsApiTicketAsync(string appId, WillExpireData ticket)
        {
            throw new NotImplementedException();
        }
    }
}
