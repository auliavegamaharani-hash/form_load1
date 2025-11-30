using form_load1.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form_load1
{
    public partial class frmMain : Form
    {
        private Form ActiveForm = null;
        private bool _isMenuCollapsed = true;
        private const int WIDTH_COLLAPSED = 70;
        private const int WIDTH_EXPANDED = 201;

        public frmMain()
        {

            InitializeComponent();
        }
           private void OpenChildForm(Form ChildForm)
        {
            if (ActiveForm != null)
                ActiveForm.Close();

            ActiveForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;

            panelTileBar.Controls.Clear();
            panelTileBar.Controls.Add(ChildForm);
            panelTileBar.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
            pagename.Text = ChildForm.Tag != null ?
                ChildForm.Tag.ToString().ToUpper() : "Form Not Found";


        }

        private void MaiForm_Load(object sender, EventArgs e) 
        {
            OpenChildForm(new frmDashboard());
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDashboard());
        }

        private void ApplyMenuState()
        {
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(822, 461);
            this.Name = "frmMain";
            this.ResumeLayout(false);

        }
    }
}
