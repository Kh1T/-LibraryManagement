using LibraryManagement.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create and show login form
            frmLogin loginForm = new frmLogin();
            loginForm.ShowDialog();

            // Check if login was successful
            // Note: Form is ALREADY closed when ShowDialog() returns
            // DO NOT call Close() again - it will cause issues!
            bool loginSuccess = (loginForm.DialogResult == DialogResult.OK);
            loginForm.Dispose();

            if (loginSuccess)
            {
                // Open main form in maximized state
                frmMain mainForm = new frmMain();
                mainForm.WindowState = FormWindowState.Maximized;
                Application.Run(mainForm);
            }
            // If login failed or cancelled, application exits
        }
    }
}
