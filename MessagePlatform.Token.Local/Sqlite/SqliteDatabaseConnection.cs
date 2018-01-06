using Suucha.WeChat.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace Suucha.WeChat.MessagePlatform.Token.Local.Sqlite
{
    public class SqliteDatabaseConnection : IDatabase
    {
        public void CreateDatabaseNecessary()
        {
            throw new NotImplementedException();
        }

        public DbConnection GetConnection()
        {
            throw new NotImplementedException();
        }
    }
}
