using System;
using System.Data;
using System.Windows.Forms;
using SistemDataSiswa; 
using System.Globalization;

namespace form_load1
{
    public partial class frmSiswa : Form
    {
       
        private SiswaRepository siswaRepository = new SiswaRepository();
        private int selectedSiswaId = 0; 
        public frmSiswa()
        {
            InitializeComponent();
        }

        private void frmSiswa_Load(object sender, EventArgs e)
        {
            
            dgvSiswa.ReadOnly = true;
            dgvSiswa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

           
            cbakhlak.Items.Add("A (Baik Sekali)");
            cbakhlak.Items.Add("B (Baik)");
            cbakhlak.Items.Add("C (Cukup)");
            cbakhlak.Items.Add("D (Kurang)");

            
            cbkls.Items.Add("XI");
            cbkls.Items.Add("XII");

            
            cbjurusan.Items.Add("PPLG");
            cbjurusan.Items.Add("TJKT");
            cbjurusan.Items.Add("AKL");

            LoadDataSiswa();
            ClearForm(); 
        }

       
        private void LoadDataSiswa()
        {
            try
            {
                DataTable dt = siswaRepository.GetAllSiswa();
                dgvSiswa.DataSource = dt;
                dgvSiswa.Columns["id"].Visible = false; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data siswa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
           
            tbnisn.Clear();
            tbnama.Clear();
            tbratanilai.Clear();
            cbkls.SelectedIndex = -1;
            cbjurusan.SelectedIndex = -1;
            cbakhlak.SelectedIndex = -1;

            
            selectedSiswaId = 0;
            btninsert.Enabled = true;
            btnupdate.Enabled = false;
            btndelete.Enabled = false;
        }

        
        private bool ValidateForm()
        {
            
            if (string.IsNullOrWhiteSpace(tbnisn.Text) ||
                string.IsNullOrWhiteSpace(tbnama.Text) ||
                string.IsNullOrWhiteSpace(tbratanilai.Text) ||
                cbkls.SelectedIndex == -1 ||
                cbjurusan.SelectedIndex == -1 ||
                cbakhlak.SelectedIndex == -1)
            {
                MessageBox.Show("Semua field harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            
            if (!float.TryParse(tbratanilai.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
            {
                MessageBox.Show("Rata-Rata Nilai harus berupa angka yang valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbratanilai.Focus();
                return false;
            }
            return true;
        }

       

        // Fungsi untuk mengambil Grade (A, B, C, D) dari ComboBox (contoh: "A (Baik Sekali)")
        private string GetGradeFromComboBox(string fullText)
        {
            if (string.IsNullOrEmpty(fullText)) return "";
            // Mengambil karakter pertama ('A', 'B', 'C', atau 'D')
            return fullText.Substring(0, 1);
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            SiswaModel siswa = new SiswaModel
            {
                Nisn = tbnisn.Text.Trim(),
                Nama = tbnama.Text.Trim(),
                Kelas = cbkls.SelectedItem.ToString(),
                Jurusan = cbjurusan.SelectedItem.ToString(),
                NilaiAkhlak = GetGradeFromComboBox(cbakhlak.SelectedItem.ToString()),
                RataNilai = float.Parse(tbratanilai.Text, CultureInfo.InvariantCulture)
            };

            if (siswaRepository.InsertSiswa(siswa))
            {
                MessageBox.Show("Data siswa berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataSiswa();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Gagal menambahkan data. NISN mungkin sudah ada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (selectedSiswaId == 0)
            {
                MessageBox.Show("Pilih data yang akan diupdate terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateForm()) return;

            SiswaModel siswa = new SiswaModel
            {
                Id = selectedSiswaId,
                Nisn = tbnisn.Text.Trim(),
                Nama = tbnama.Text.Trim(),
                Kelas = cbkls.SelectedItem.ToString(),
                Jurusan = cbjurusan.SelectedItem.ToString(),
                NilaiAkhlak = GetGradeFromComboBox(cbakhlak.SelectedItem.ToString()),
                RataNilai = float.Parse(tbratanilai.Text, CultureInfo.InvariantCulture)
            };

            if (siswaRepository.UpdateSiswa(siswa))
            {
                MessageBox.Show("Data siswa berhasil diupdate!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataSiswa();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Gagal mengupdate data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (selectedSiswaId == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Yakin hapus data ID: {selectedSiswaId}?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (siswaRepository.DeleteSiswa(selectedSiswaId))
                {
                    MessageBox.Show("Data siswa berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataSiswa();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Gagal menghapus data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim(); 
            if (string.IsNullOrEmpty(keyword))
            {
                LoadDataSiswa(); 
                return;
            }

            try
            {
                DataTable dt = siswaRepository.SearchSiswa(keyword);
                dgvSiswa.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

       
        private void dgvSiswa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSiswa.Rows[e.RowIndex];

                // Ambil ID untuk operasi Update/Delete
                selectedSiswaId = Convert.ToInt32(row.Cells["id"].Value);

                // Isi form input
                tbnisn.Text = row.Cells["nisn"].Value.ToString();
                tbnama.Text = row.Cells["nama"].Value.ToString();
                tbratanilai.Text = row.Cells["rata_nilai"].Value.ToString();
                cbkls.SelectedItem = row.Cells["kelas"].Value.ToString();
                cbjurusan.SelectedItem = row.Cells["jurusan"].Value.ToString();

                string nilaiAkhlakDB = row.Cells["nilai_akhlak"].Value.ToString();

                // Cari dan set ComboBox Akhlak berdasarkan nilai grade (A, B, C, D)
                foreach (string item in cbakhlak.Items)
                {
                    if (item.StartsWith(nilaiAkhlakDB))
                    {
                        cbakhlak.SelectedItem = item;
                        break;
                    }
                }

                // Atur status tombol
                btninsert.Enabled = false;
                btnupdate.Enabled = true;
                btndelete.Enabled = true;
            }
        }
    }
}