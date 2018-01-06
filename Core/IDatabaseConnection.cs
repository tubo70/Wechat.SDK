using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Suucha.WeChat.Core
{
    public interface IDatabase
    {
        /// <summary>
        /// Creates the database necessary.
        /// </summary>
        void CreateDatabaseNecessary();

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        DbConnection GetConnection();
    }
}
