using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Snake
{
    public class DB
    {
        static string connectionString = "Data Source=DESKTOP-DUM1K4O;Initial Catalog=Snake;Integrated Security=True";
        private SqlConnection sqlConnection = new SqlConnection(connectionString);
        public async void openConnection()
        {
            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    await sqlConnection.OpenAsync();
            }
            catch
            {
                Console.WriteLine("Turn on Server");
            }
        }
        public void closeConnection()
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }
        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}
