using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Utilities
{
    internal class Util
    {
        public static string GetConnectionString()
        {
            string connectionSting = "Server=DESKTOP-G8172MG\\SQLEXPRESS01;Database=BuzzTalk;Trusted_Connection=True;";
            return connectionSting;

        }

        public static SqlConnection GetSqlConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
