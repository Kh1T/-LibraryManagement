// Forms/frmMain.cs
using System;
using System.Windows.Forms;
using LibraryManagement.Forms;

namespace LibraryManagement.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            if (!ShowLogin())
            {
                // If login failed, close application
                this.Close();
                return;
            }
            this.Text = "📚 Library Management System";
        }
        private bool ShowLogin()
        {
            using (frmLogin loginForm = new frmLogin())
            {
                return loginForm.ShowDialog() == DialogResult.OK;
            }
        }
        private void btnBooks_Click_1(object sender, EventArgs e)
        {
            frmBooks frm = new frmBooks();
            frm.WindowState = FormWindowState.Minimized;
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMembers frm = new frmMembers();
            frm.WindowState = FormWindowState.Minimized;
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmLoan frm = new frmLoan();
            frm.WindowState = FormWindowState.Minimized;
            frm.ShowDialog();
        }
    }
}