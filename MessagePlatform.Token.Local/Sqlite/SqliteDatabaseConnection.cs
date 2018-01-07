using Suucha.WeChat.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Configuration;
using Microsoft.Data.Sqlite;

namespace Suucha.WeChat.MessagePlatform.Token.Local.Sqlite
{
    public class SqliteDatabase : IDatabase
    {
        string connectionString;
        public SqliteDatabase()
        {
            connectionString = ConfigurationManager.ConnectionStrings["messagePlatform"].ConnectionString;
        }
        public void CreateDatabaseNecessary()
        {
            string messagePlatformSql = @"create table if not exists message_platform(
                        app_id varchar(64) PRIMARY KEY , 
                        app_token varchar(50), 
                        app_secret varchar(50), 
                        encoding_aes_key varchar(50),
                        access_token varchar(1000),
                        js_api_ticket varchar(1000))";
            using(var connection = GetConnection())
            {
                connection.Open();
                var command = new SqliteCommand(messagePlatformSql, (SqliteConnection)connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public DbConnection GetConnection()
        {
            DbConnection connection = new SqliteConnection(connectionString);
            return connection;
        }
    }
}
