using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Load
    {
        DB db = new DB();
        public Load(char[,] spaceTemp)
        {
            db.openConnection();
            int rows = spaceTemp.GetUpperBound(0) + 1;
            int columns = spaceTemp.Length / rows;
            SqlCommand command = new SqlCommand("INSERT INTO dbo.SnakeTable (gameLoaded) VALUES (@gL);", db.GetConnection());
            command.Parameters.Add("@gL", SqlDbType.Int).Value = rows;


            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            //SqlCommand command = new SqlCommand("SELECT * FROM dbo.SnakeTable WHERE gameLoaded = @gL", db.GetConnection());
            //command.Parameters.Add("@gL", SqlDbType.Int).Value = 1;

            //adapter.SelectCommand = command;
            //adapter.Fill(table);

            //if (table.Rows.Count > 0)
            //{
            //    Console.WriteLine("YES");
            //}
            //else
            //{
            //    Console.WriteLine("NO");
            //}
                //for (int i = 0; i < columns; i++)
                //{
                //    for (int j = 0; j < rows; j++)
                //    {
                //        command.Parameters.Add("@Symbol", SqlDbType.VarChar).Value = spaceTemp[i, j];
                //        command.Parameters.Add("@x", SqlDbType.Int).Value = j;
                //        command.Parameters.Add("@y", SqlDbType.Int).Value = i;
                //    }
                //}
                db.closeConnection();
        }
    }
}
