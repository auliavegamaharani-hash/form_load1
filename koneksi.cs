using System;
using System.Data;
using System.Data.SqlClient;

namespace form_load1
{
    class Koneksi
    {
        // Ganti Data Source dengan nama servermu yang benar
        private string connString = "Data Source=LAPTOP-KAMU;Initial Catalog=NamaDatabaseKamu;Integrated Security=True";

        public SqlConnection GetCon()
        {
            SqlConnection conn = new SqlConnection(connString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
    }
}