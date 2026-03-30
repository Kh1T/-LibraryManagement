using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class frmLogin : Form
    {
        private bool isLoggedIn = false;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Prevent double click
            if (isLoggedIn) return;
            isLoggedIn = true;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Check credentials
            if (username == "admin" && password == "admin")
            {
                // Setting DialogResult automatically closes the form (when shown with ShowDialog)
                // DO NOT call Close() - it causes issues!
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Login Failed",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
                isLoggedIn = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Setting DialogResult automatically closes the form
            this.DialogResult = DialogResult.Cancel;
        }

        private void lblAppName_Click(object sender, EventArgs e)
        {

        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelLoginCard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
