using System;

namespace YourNamespace
{
    public class SiswaModel
    {
        // Sesuai dengan kolom di tabel Siswa
        public int Id { get; set; }
        public string Nisn { get; set; }
        public string Nama { get; set; }
        public string Kelas { get; set; }
        public string Jurusan { get; set; }
        public string NilaiAkhlak { get; set; } // char(1) atau varchar(2) [cite: 23]
        public float RataNilai { get; set; }     // float [cite: 24]
    }
}