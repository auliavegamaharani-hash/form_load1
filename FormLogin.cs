using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace form_load1
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void FormLogin_Load(object sender, EventArgs e) { }

        // --- INI BAGIAN YANG HARUS DIPERBAIKI (Tombol Login) ---


        private void button1_Click(object sender, EventArgs e)
        {
            if (Username.Text == "" |Password.Text == "")
            {
                MessageBox.Show("Username dan Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Siapkan Query SQL
                // Ganti 'TabelUser' dengan nama tabel aslimu (misal: users, admin, petugas)
                string query = string.Format("SELECT * FROM Tabel User WHERE username = '{0}' AND password = '{1}'",
                                             Username.Text ,Password.Text);

                // 3. Panggil DbHelper untuk eksekusi query
                DataTable dt = DbHelper.ExecuteQuery(query);

                // 4. Cek apakah ada data yang ditemukan (baris > 0)
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login Berhasil!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Buka Form Utama (frmMain)
                    frmMain mainForm = new frmMain();
                    mainForm.Show();

                    // Sembunyikan Form Login
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username atau Password salah.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }

        }
    }
}

