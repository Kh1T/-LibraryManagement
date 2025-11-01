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
            this.Text = "📚 Library Management System";
        }

        //private void btnMembers_Click(object sender, EventArgs e)
        //{
        //    new MembersForm().ShowDialog();
        //}

        //private void btnTransactions_Click(object sender, EventArgs e)
        //{
        //    new TransactionsForm().ShowDialog();
        //}

        //private void btnLoans_Click(object sender, EventArgs e)
        //{
        //    new LoansForm().ShowDialog();
        //}

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBooks_Click_1(object sender, EventArgs e)
        {
            //new frmBooks().ShowDialog();
            frmBooks frm = new frmBooks();
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }
    }
}