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
            this.Hide();
            using (frmBooks frm = new frmBooks())
            {
                frm.ShowDialog();
            }
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (frmMembers frm = new frmMembers())
            {
                frm.ShowDialog();
            }
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (frmLoan frm = new frmLoan())
            {
                frm.ShowDialog();
            }
            this.Show();
        }
    }
}