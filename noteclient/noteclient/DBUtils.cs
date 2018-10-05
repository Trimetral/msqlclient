using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace connectmsql
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "95.84.154.71";
            int port = 3308;
            string database = "test";
            string username = "Test";
            string password = "JyA2aM3qydPVCfe";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
