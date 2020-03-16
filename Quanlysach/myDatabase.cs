using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Quanlysach
{
    class myDatabase
    {
        string conSt = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLSach;Integrated Security=True";
        SqlConnection myConnection;
        public myDatabase()
        {
            myConnection = new SqlConnection(conSt);
        }
        public DataTable getData(string sql)
        {
            SqlDataAdapter myDa = new SqlDataAdapter(sql, myConnection);
            DataTable myDt = new DataTable();
            myDa.Fill(myDt);
            return myDt;
        }
        public void runQuery(string sql)
        {
            myConnection.Open();
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            cmd.ExecuteNonQuery();
            myConnection.Close();


        }

    }
}
