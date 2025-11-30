namespace form_load1
{
    partial class frmSiswa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbnisn = new System.Windows.Forms.TextBox();
            this.tbnama = new System.Windows.Forms.TextBox();
            this.tbratanilai = new System.Windows.Forms.TextBox();
            this.cbkls = new System.Windows.Forms.ComboBox();
            this.cbjurusan = new System.Windows.Forms.ComboBox();
            this.cbakhlak = new System.Windows.Forms.ComboBox();
            this.btninsert = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnsearch = new System.Windows.Forms.Button();
            this.dgvSiswa = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiswa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Siswa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(137, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "NISN:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(137, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nama Lengkap:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(137, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rata Rata Nilai:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(137, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Kelas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(137, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Jurusan";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(137, 346);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 22);
            this.label7.TabIndex = 6;
            this.label7.Text = "Nilai Akhlak";
            // 
            // tbnisn
            // 
            this.tbnisn.Location = new System.Drawing.Point(309, 99);
            this.tbnisn.Name = "tbnisn";
            this.tbnisn.Size = new System.Drawing.Size(250, 22);
            this.tbnisn.TabIndex = 7;
            // 
            // tbnama
            // 
            this.tbnama.Location = new System.Drawing.Point(309, 146);
            this.tbnama.Name = "tbnama";
            this.tbnama.Size = new System.Drawing.Size(250, 22);
            this.tbnama.TabIndex = 8;
            // 
            // tbratanilai
            // 
            this.tbratanilai.Location = new System.Drawing.Point(309, 192);
            this.tbratanilai.Name = "tbratanilai";
            this.tbratanilai.Size = new System.Drawing.Size(132, 22);
            this.tbratanilai.TabIndex = 9;
            // 
            // cbkls
            // 
            this.cbkls.FormattingEnabled = true;
            this.cbkls.Location = new System.Drawing.Point(309, 247);
            this.cbkls.Name = "cbkls";
            this.cbkls.Size = new System.Drawing.Size(132, 24);
            this.cbkls.TabIndex = 10;
            // 
            // cbjurusan
            // 
            this.cbjurusan.FormattingEnabled = true;
            this.cbjurusan.Location = new System.Drawing.Point(309, 296);
            this.cbjurusan.Name = "cbjurusan";
            this.cbjurusan.Size = new System.Drawing.Size(132, 24);
            this.cbjurusan.TabIndex = 11;
            // 
            // cbakhlak
            // 
            this.cbakhlak.FormattingEnabled = true;
            this.cbakhlak.Location = new System.Drawing.Point(309, 347);
            this.cbakhlak.Name = "cbakhlak";
            this.cbakhlak.Size = new System.Drawing.Size(132, 24);
            this.cbakhlak.TabIndex = 12;
            // 
            // btninsert
            // 
            this.btninsert.BackColor = System.Drawing.Color.Pink;
            this.btninsert.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btninsert.Location = new System.Drawing.Point(216, 396);
            this.btninsert.Name = "btninsert";
            this.btninsert.Size = new System.Drawing.Size(102, 30);
            this.btninsert.TabIndex = 13;
            this.btninsert.Text = "Insert";
            this.btninsert.UseVisualStyleBackColor = false;
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnupdate.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.Location = new System.Drawing.Point(337, 396);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(102, 30);
            this.btnupdate.TabIndex = 14;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.IndianRed;
            this.btndelete.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.Location = new System.Drawing.Point(457, 396);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(102, 30);
            this.btndelete.TabIndex = 15;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = false;
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.LightGray;
            this.btnsearch.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.Location = new System.Drawing.Point(562, 451);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(102, 30);
            this.btnsearch.TabIndex = 16;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = false;
            // 
            // dgvSiswa
            // 
            this.dgvSiswa.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSiswa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSiswa.Location = new System.Drawing.Point(95, 504);
            this.dgvSiswa.Name = "dgvSiswa";
            this.dgvSiswa.RowHeadersWidth = 51;
            this.dgvSiswa.RowTemplate.Height = 24;
            this.dgvSiswa.Size = new System.Drawing.Size(569, 142);
            this.dgvSiswa.TabIndex = 17;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(95, 456);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(445, 22);
            this.txtSearch.TabIndex = 18;
            // 
            // frmSiswa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 686);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvSiswa);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btninsert);
            this.Controls.Add(this.cbakhlak);
            this.Controls.Add(this.cbjurusan);
            this.Controls.Add(this.cbkls);
            this.Controls.Add(this.tbratanilai);
            this.Controls.Add(this.tbnama);
            this.Controls.Add(this.tbnisn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSiswa";
            this.Text = "frmSiswa";
            this.Load += new System.EventHandler(this.frmSiswa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiswa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbnisn;
        private System.Windows.Forms.TextBox tbnama;
        private System.Windows.Forms.TextBox tbratanilai;
        private System.Windows.Forms.ComboBox cbkls;
        private System.Windows.Forms.ComboBox cbjurusan;
        private System.Windows.Forms.ComboBox cbakhlak;
        private System.Windows.Forms.Button btninsert;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.DataGridView dgvSiswa;
        private System.Windows.Forms.TextBox txtSearch;
    }
}