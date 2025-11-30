using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace form_load1
{
    public partial class frmSiswa : Form
    {
        private string idSiswa = "";
        private readonly AutoCompleteStringCollection _searchAutoComplete = new AutoCompleteStringCollection();
        private readonly HashSet<string> _searchHistory = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private const string SearchPlaceholder = "Search";

        public frmSiswa()
        {
            InitializeComponent();

            // Setup Autocomplete untuk TextBox Search (txtSearch)
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSearch.AutoCompleteCustomSource = _searchAutoComplete;

            this.AutoScroll = true;

           
            this.AutoScrollMinSize = new Size(0, 800);

           
            Load += FrmSiswa_Load;



            dgvSiswa.CellClick += Dgv_CellClick; 

            txtSearch.KeyDown += Tbsearch_KeyDown;
            txtSearch.GotFocus += Tbsearch_GotFocus;
            txtSearch.LostFocus += Tbsearch_LostFocus;
        }

        private void FrmSiswa_Load(object sender, EventArgs e)
        {
            // load data from DB (keeps existing behavior)
            TampilData();
            PopulateComboBoxes();
            InitializeSearchPlaceholder();

            // Override/ensure the exact items you want — do this after PopulateComboBoxes
            cbkls.Items.Clear();
            cbkls.Items.AddRange(new object[] { "X", "XI", "XII" });

            cbjurusan.Items.Clear();
            cbjurusan.Items.AddRange(new object[] { "TJKT", "PPLG", "DKV", "AKL", "MPLB" });

            cbakhlak.Items.Clear();
            cbakhlak.Items.AddRange(new object[] { "A", "B", "C", "D" });

            // Select a sensible default
            cbkls.SelectedIndex = 0;
            cbjurusan.SelectedIndex = 0;
            cbakhlak.SelectedIndex = 0;
        }

        private void TampilData()
        {
            try
            {
               
                string query = "SELECT * FROM [Tabel Siswa]";
                DataTable dt = DbHelper.ExecuteQuery(query);
                dgvSiswa.DataSource = dt;
                dgvSiswa.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateComboBoxes()
        {
            try
            {
                var kelasSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                var jurusanSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                var akhlakSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                using (SqlConnection conn = DbHelper.GetConnection())
                {
                   
                    using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT kelas FROM [Tabel Siswa] WHERE kelas IS NOT NULL", conn))
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            var v = r.IsDBNull(0) ? string.Empty : r.GetString(0).Trim();
                            if (!string.IsNullOrEmpty(v)) kelasSet.Add(v);
                        }
                    }

                    
                    using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT jurusan FROM [Tabel Siswa] WHERE jurusan IS NOT NULL", conn))
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            var v = r.IsDBNull(0) ? string.Empty : r.GetString(0).Trim();
                            if (!string.IsNullOrEmpty(v)) jurusanSet.Add(v);
                        }
                    }

                    
                    using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT nilai_akhlak FROM [Tabel Siswa] WHERE nilai_akhlak IS NOT NULL", conn))
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            var v = r.IsDBNull(0) ? string.Empty : r.GetValue(0)?.ToString().Trim();
                            if (!string.IsNullOrEmpty(v)) akhlakSet.Add(v);
                        }
                    }
                }

                
                var kelasItems = kelasSet.OrderBy(x => x).ToArray();
                var jurusanItems = jurusanSet.OrderBy(x => x).ToArray();
                var akhlakItems = akhlakSet.OrderBy(x => x).ToArray();

                cbkls.Items.Clear();
                if (kelasItems.Length > 0) cbkls.Items.AddRange(kelasItems);
                else cbkls.Items.AddRange(new object[] { "10", "11", "12" });

                cbjurusan.Items.Clear(); 
                if (jurusanItems.Length > 0) cbjurusan.Items.AddRange(jurusanItems);
                else cbjurusan.Items.AddRange(new object[] { "PPLG", "MPLB", "TJKT", "DKV", "AK" });

                cbakhlak.Items.Clear(); 
                if (akhlakItems.Length > 0) cbakhlak.Items.AddRange(akhlakItems);
                else cbakhlak.Items.AddRange(new object[] { "A", "B", "C", "D" });

               
                if (cbkls.Items.Count > 0) cbkls.SelectedIndex = 0;
                if (cbjurusan.Items.Count > 0) cbjurusan.SelectedIndex = 0;
                if (cbakhlak.Items.Count > 0) cbakhlak.SelectedIndex = 0;
            }
            catch
            {
               
                if (cbkls.Items.Count == 0) cbkls.Items.AddRange(new object[] { "10", "11", "12" });
                if (cbjurusan.Items.Count == 0) cbjurusan.Items.AddRange(new object[] { "PPLG", "MPLB", "TJKT", "DKV", "AK" });
                if (cbakhlak.Items.Count == 0) cbakhlak.Items.AddRange(new object[] { "A", "B", "C", "D" });
            }
        }

        private void Btninsert_Click(object sender, EventArgs e)
        {
            
            var missing = new List<string>();
            if (string.IsNullOrWhiteSpace(tbnisn.Text)) missing.Add("NISN");
            if (string.IsNullOrWhiteSpace(tbnama.Text)) missing.Add("Nama Lengkap");
            if (string.IsNullOrWhiteSpace(cbkls.Text)) missing.Add("Kelas");
            if (string.IsNullOrWhiteSpace(cbjurusan.Text)) missing.Add("Jurusan");
            if (string.IsNullOrWhiteSpace(cbakhlak.Text)) missing.Add("Nilai Akhlak");
            if (string.IsNullOrWhiteSpace(tbratanilai.Text)) missing.Add("Rata-rata Nilai");

            if (missing.Count > 0)
            {
                MessageBox.Show("Field kosong: " + string.Join(", ", missing), "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (!decimal.TryParse(tbratanilai.Text.Trim(), out decimal rataNilai))
            {
                MessageBox.Show("Rata-rata nilai harus berupa angka.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbratanilai.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                using (SqlCommand cmd = conn.CreateCommand())
                {
                   
                    cmd.CommandText = @"INSERT INTO [Tabel Siswa] (nisn, nama, kelas, jurusan, nilai_akhlak, rata_nilai)
                                        VALUES (@nisn, @nama, @kelas, @jurusan, @nilai_akhlak, @rata_nilai)";
                    cmd.Parameters.AddWithValue("@nisn", tbnisn.Text.Trim());
                    cmd.Parameters.AddWithValue("@nama", tbnama.Text.Trim());
                    cmd.Parameters.AddWithValue("@kelas", cbkls.Text.Trim());
                    cmd.Parameters.AddWithValue("@jurusan", cbjurusan.Text.Trim());
                    cmd.Parameters.AddWithValue("@nilai_akhlak", cbakhlak.Text.Trim());
                    cmd.Parameters.AddWithValue("@rata_nilai", rataNilai);

                    int affected = cmd.ExecuteNonQuery();
                    if (affected > 0)
                    {
                        MessageBox.Show("Data berhasil ditambahkan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputs();
                        TampilData();
                        PopulateComboBoxes(); 
                    }
                    else
                    {
                       
                        MessageBox.Show("Gagal menambahkan data. Affected rows = 0.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btnup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbnisn.Text))
            {
                MessageBox.Show("Pilih baris yang akan diubah.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                using (SqlCommand cmd = conn.CreateCommand())
                {
                   
                    if (ColumnExists(null, "Id"))
                    {
                        cmd.CommandText = @"UPDATE [Tabel Siswa] SET nisn=@nisn, nama=@nama, kelas=@kelas, jurusan=@jurusan, nilai_akhlak=@nilai_akhlak, rata_nilai=@rata_nilai WHERE Id=@id";
                        cmd.Parameters.AddWithValue("@id", idSiswa);
                    }
                    else
                    {
                        cmd.CommandText = @"UPDATE [Tabel Siswa] SET nisn=@nisn, nama=@nama, kelas=@kelas, jurusan=@jurusan, nilai_akhlak=@nilai_akhlak, rata_nilai=@rata_nilai WHERE nisn=@orignisn";
                        cmd.Parameters.AddWithValue("@orignisn", idSiswa);
                    }

                    cmd.Parameters.AddWithValue("@nisn", tbnisn.Text.Trim());
                    cmd.Parameters.AddWithValue("@nama", tbnama.Text.Trim());
                    cmd.Parameters.AddWithValue("@kelas", cbkls.Text.Trim());
                    cmd.Parameters.AddWithValue("@jurusan", cbjurusan.Text.Trim());
                    cmd.Parameters.AddWithValue("@nilai_akhlak", cbakhlak.Text.Trim());
                    cmd.Parameters.AddWithValue("@rata_nilai", tbratanilai.Text.Trim());

                    int affected = cmd.ExecuteNonQuery();
                    if (affected > 0)
                    {
                        MessageBox.Show("Data berhasil diupdate.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputs();
                        TampilData();
                    }
                    else
                    {
                        MessageBox.Show("Update gagal. Pastikan data terpilih.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btndel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbnisn.Text))
            {
                MessageBox.Show("Pilih baris yang akan dihapus.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Tabel Siswa] WHERE nisn = @nisn";
                    cmd.Parameters.AddWithValue("@nisn", tbnisn.Text.Trim());

                    int affected = cmd.ExecuteNonQuery();
                    if (affected > 0)
                    {
                        MessageBox.Show("Data berhasil dihapus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputs();
                        TampilData();
                    }
                    else
                    {
                        MessageBox.Show("Data gagal dihapus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void Btncl_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            idSiswa = "";
            tbnisn.Text = "";
            tbnama.Text = "";
            cbkls.SelectedIndex = -1;
            cbjurusan.SelectedIndex = -1;
            cbakhlak.SelectedIndex = -1;
            tbratanilai.Text = "";

          
            btninsert.Enabled = true;
            btnupdate.Enabled = true;
            btndelete.Enabled = true;
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvSiswa.Rows[e.RowIndex];
            try
            {
                tbnisn.Text = GetCellValueSafe(row, "nisn") ?? row.Cells[0].Value?.ToString();
                tbnama.Text = GetCellValueSafe(row, "nama");
                cbkls.Text = GetCellValueSafe(row, "kelas");
                cbjurusan.Text = GetCellValueSafe(row, "jurusan");
                cbakhlak.Text = GetCellValueSafe(row, "nilai_akhlak");
                tbratanilai.Text = GetCellValueSafe(row, "rata_nilai");

               
                if (ColumnExists(row, "Id"))
                    idSiswa = GetCellValueSafe(row, "Id");
                else
                    idSiswa = tbnisn.Text;
            }
            catch { }
        }

        private string GetCellValueSafe(DataGridViewRow row, string columnName)
        {
            if (dgvSiswa.Columns.Contains(columnName) && row.Cells[columnName].Value != null)
                return row.Cells[columnName].Value.ToString();
            return string.Empty;
        }

        private void Btnsrch_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        private void Tbsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoSearch();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void DoSearch()
        {
            string q = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(q) || string.Equals(q, SearchPlaceholder, StringComparison.OrdinalIgnoreCase))
            {
                TampilData();
                return;
            }

            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM [Tabel Siswa]
                                        WHERE CAST(nisn AS VARCHAR(100)) LIKE @q
                                           OR nama LIKE @q
                                           OR kelas LIKE @q
                                           OR jurusan LIKE @q
                                           OR CAST(rata_nilai AS VARCHAR(100)) LIKE @q
                                           OR nilai_akhlak LIKE @q";
                    cmd.Parameters.AddWithValue("@q", "%" + q + "%");

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvSiswa.DataSource = dt;
                    }
                }

                
                if (!string.IsNullOrWhiteSpace(q))
                {
                    if (_searchHistory.Contains(q))
                    {
                        _searchAutoComplete.Remove(q);
                        _searchAutoComplete.Insert(0, q);
                    }
                    else
                    {
                        _searchHistory.Add(q);
                        _searchAutoComplete.Insert(0, q);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeSearchPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.ForeColor = SystemColors.GrayText;
                txtSearch.Text = SearchPlaceholder;
            }
        }

        private void Tbsearch_GotFocus(object sender, EventArgs e)
        {
            if (string.Equals(txtSearch.Text, SearchPlaceholder, StringComparison.OrdinalIgnoreCase))
            {
                txtSearch.Text = string.Empty;
                txtSearch.ForeColor = SystemColors.WindowText;
            }
        }

        private void Tbsearch_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.ForeColor = SystemColors.GrayText;
                txtSearch.Text = SearchPlaceholder;
            }
        }

        private bool ColumnExists(DataGridViewRow row, string columnName)
        {
            if (dgvSiswa == null) return false;
            return dgvSiswa.Columns.Cast<DataGridViewColumn>()
                   .Any(c => string.Equals(c.Name, columnName, StringComparison.OrdinalIgnoreCase));
        }
    }
}