using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

namespace QA_Project_1.Utils
{
    class SqlUtils
    {
        public static MySqlConnectionStringBuilder ConnectionString { get; set; } = new MySqlConnectionStringBuilder
        {
            Server = "127.0.0.1", // server hosting the mysql server
            UserID = "root", // user id for mysql
            Password = "root", // password for mysql
            Port = 3306, // port to connect on, 3306 is default for MySQL
            Database = "salesDb", // name of db to connect to in rdbms
            AllowBatch = true, // allows batches of commands to be sent, defaults to true,
            AllowLoadLocalInfileInPath = "./", // only files in specified dir can be uploaded,
            AllowLoadLocalInfile = false,
            ConnectionTimeout = 30
        };

        public static MySqlConnection GetConnection() 
        {
            return new MySqlConnection(ConnectionString.ConnectionString);
        }

        public static void RunSchema(string path, MySqlConnection connection)
        {
            string schema = File.ReadAllText(path);
            MySqlCommand mySqlCommand = connection.CreateCommand();
            mySqlCommand.CommandText = schema;

            mySqlCommand.ExecuteNonQuery();
        }
    }
}
