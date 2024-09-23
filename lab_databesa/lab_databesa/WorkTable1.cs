using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace lab_databesa
{
    class WorkTable1
    {
         public SqlConnection conn = new SqlConnection();
            public SqlCommand cmd = new SqlCommand();
            public DataTable tb = new DataTable();
            public WorkTable1()
{
    conn.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Project\last-project-main\lab_databesa\lab_databesa\Database1.mdf;Integrated Security=True;User Instance=True"; 
 
}
            public string RunDML(string s)
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = s;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return "ok";
                }
                catch (SqlException ex)
                {
                    conn.Close();
                    return ex.Message;
                }
            }
            public DataTable runQuery(string stmt)
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = stmt;
                    DataTable tbl = new DataTable();
                    conn.Open();
                    tbl.Load(cmd.ExecuteReader());
                    conn.Close();
                    return tbl;
                }
                catch (SqlException )
                {
                    conn.Close();
                    return null;
                }
            }
        }

    }
    

