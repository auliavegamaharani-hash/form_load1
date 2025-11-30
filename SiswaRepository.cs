using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace YourNamespace // <-- Add a valid namespace identifier here
{
    public class SiswaRepository
    {
        // Use fully-qualified table name (schema + table). Adjust if your real table name/schema differ.
        private const string TableName = "[dbo].[siswa]";

        // 1. FUNGSI INSERT
        public bool InsertSiswa(SiswaModel siswa)
        {
            string sql = $"INSERT INTO {TableName} (nisn, nama, kelas, jurusan, nilai_akhlak, rata_nilai) " +
                         "VALUES (@nisn, @nama, @kelas, @jurusan, @nilai_akhlak, @rata_nilai)";

            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nisn", siswa.Nisn);
                        cmd.Parameters.AddWithValue("@nama", siswa.Nama);
                        cmd.Parameters.AddWithValue("@kelas", siswa.Kelas);
                        cmd.Parameters.AddWithValue("@jurusan", siswa.Jurusan);
                        cmd.Parameters.AddWithValue("@nilai_akhlak", siswa.NilaiAkhlak);
                        cmd.Parameters.AddWithValue("@rata_nilai", siswa.RataNilai);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal Insert: " + ex.Message);
                return false;
            }
        }

        // 2. FUNGSI GET ALL
        public DataTable GetAllSiswa()
        {
            string sql = $"SELECT id, nisn, nama, kelas, jurusan, nilai_akhlak, rata_nilai FROM {TableName}";
            return DbHelper.ExecuteQuery(sql);
        }

        // 3. FUNGSI UP
        public bool UpdateSiswa(SiswaModel siswa)
        {
            string sql = $"UPDATE {TableName} SET nisn=@nisn, nama=@nama, kelas=@kelas, jurusan=@jurusan, " +
                         "nilai_akhlak=@nilai_akhlak, rata_nilai=@rata_nilai WHERE id=@id";

            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", siswa.Id);
                        cmd.Parameters.AddWithValue("@nisn", siswa.Nisn);
                        cmd.Parameters.AddWithValue("@nama", siswa.Nama);
                        cmd.Parameters.AddWithValue("@kelas", siswa.Kelas);
                        cmd.Parameters.AddWithValue("@jurusan", siswa.Jurusan);
                                  cmd.Parameters.AddWithValue("@nilai_akhlak", siswa.NilaiAkhlak);
                        cmd.Parameters.AddWithValue("@rata_nilai", siswa.RataNilai);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal Update: " + ex.Message);
                return false;
            }
        }

        // 4. FUNGSI DELETE
        public bool DeleteSiswa(int id)
        {
            string sql = $"DELETE FROM {TableName} WHERE id=@id";
            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal Delete: " + ex.Message);
                return false;
            }
        }

        // 5. FUNGSI SEARCH
        public DataTable SearchSiswa(string keyword)
        {
            string sql = $"SELECT id, nisn, nama, kelas, jurusan, nilai_akhlak, rata_nilai FROM {TableName} " +
                         "WHERE nisn LIKE @keyword OR nama LIKE @keyword";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}