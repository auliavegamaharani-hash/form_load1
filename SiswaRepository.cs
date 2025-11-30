using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace SistemDataSiswa
{
    public class SiswaRepository
    {
        
        public bool InsertSiswa(SiswaModel siswa)
        {
            
            string sql = string.Format(
                "INSERT INTO Siswa (nisn, nama, kelas, jurusan, nilai_akhlak, rata_nilai) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', {5})",
                siswa.Nisn, siswa.Nama, siswa.Kelas, siswa.Jurusan, siswa.NilaiAkhlak, siswa.RataNilai);

            
            int affectedRows = DbHelper.ExecuteNonQuery(sql);
            return affectedRows > 0;
        }

        
        public DataTable GetAllSiswa()
        {
            string sql = "SELECT id, nisn, nama, kelas, jurusan, nilai_akhlak, rata_nilai FROM Siswa";
            
            return DbHelper.ExecuteQuery(sql);
        }

        
        public bool UpdateSiswa(SiswaModel siswa)
        {
           
            string sql = string.Format(
                "UPDATE Siswa SET nisn = '{0}', nama = '{1}', kelas = '{2}', jurusan = '{3}', nilai_akhlak = '{4}', rata_nilai = {5} WHERE id = {6}",
                siswa.Nisn, siswa.Nama, siswa.Kelas, siswa.Jurusan, siswa.NilaiAkhlak, siswa.RataNilai, siswa.Id);

            int affectedRows = DbHelper.ExecuteNonQuery(sql);
            return affectedRows > 0;
        }

        
        public bool DeleteSiswa(int id)
        {
            
            string sql = string.Format("DELETE FROM Siswa WHERE id = {0}", id);

            int affectedRows = DbHelper.ExecuteNonQuery(sql);
            return affectedRows > 0;
        }

        
        public DataTable SearchSiswa(string keyword)
        {
           
            string sql = string.Format(
                "SELECT id, nisn, nama, kelas, jurusan, nilai_akhlak, rata_nilai FROM Siswa WHERE nisn LIKE '%{0}%' OR nama LIKE '%{0}%'",
                keyword);

            return DbHelper.ExecuteQuery(sql);
        }
    }
}