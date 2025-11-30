using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

public static class DbHelper
{
    // fallback if no connection string in config
    private static readonly string fallbackConString = @"Data Source=VEGA\SQLEXPRESS;Initial Catalog=SistemDataSiswa_sas;Integrated Security=True;TrustServerCertificate=True";
    private static readonly string constring = GetConnectionString();

    private static string GetConnectionString()
    {
        try
        {
            // Use reflection to avoid a compile-time dependency on System.Configuration
            var cmType = Type.GetType("System.Configuration.ConfigurationManager, System.Configuration");
            if (cmType != null)
            {
                var connStringsProp = cmType.GetProperty("ConnectionStrings", BindingFlags.Static | BindingFlags.Public);
                var connStrings = connStringsProp?.GetValue(null);
                if (connStrings != null)
                {
                    var itemProp = connStrings.GetType().GetProperty("Item", new Type[] { typeof(string) });
                    var connSetting = itemProp?.GetValue(connStrings, new object[] { "MyConnection" });
                    if (connSetting != null)
                    {
                        var csProp = connSetting.GetType().GetProperty("ConnectionString", BindingFlags.Public | BindingFlags.Instance);
                        var csValue = csProp?.GetValue(connSetting) as string;
                        if (!string.IsNullOrWhiteSpace(csValue)) return csValue;
                    }
                }
            }
        }
        catch
        {
            // ignore and fallback
        }

        return fallbackConString;
    }

    public static SqlConnection GetConnection()
    {
        SqlConnection conn = new SqlConnection(constring);
        try
        {
            conn.Open();
            return conn;
        }
        catch (Exception ex)
        {
            throw new Exception("gagal koneksi ke database:" + ex.Message);
        }
    }

    public static DataTable ExecuteQuery(string query)
    {
        using (SqlConnection conn = GetConnection())
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }

    public static int ExecuteNonQuery(string query)
    {
        using (SqlConnection conn = GetConnection())
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            return cmd.ExecuteNonQuery();
        }
    }

    public static object ExecuteScalar(string query)
    {
        using (SqlConnection conn = GetConnection())
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            return cmd.ExecuteScalar();
        }
    }

    public static bool TableExists(string schema, string tableName)
    {
        const string sql = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA=@schema AND TABLE_NAME=@table";
        using (var conn = GetConnection())
        using (var cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@schema", schema);
            cmd.Parameters.AddWithValue("@table", tableName);
            var result = cmd.ExecuteScalar();
            return Convert.ToInt32(result) > 0;
        }
    }

    public static string CurrentDatabase()
    {
        using (var conn = GetConnection())
        using (var cmd = new SqlCommand("SELECT DB_NAME()", conn))
        {
            return cmd.ExecuteScalar() as string;
                                        }
    }
}