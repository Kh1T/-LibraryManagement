// Forms/frmMain.cs
using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagement.Forms;

namespace LibraryManagement.Forms
{
    public partial class frmMain : Form
    {
        // UserControl instances
        private ucBooks ucBooksControl;
        private ucMembers ucMembersControl;
        private ucLoans ucLoansControl;
        
        // Currently displayed control
        private UserControl currentControl;
        
        // Active button tracking
        private Button activeButton;
        
        // Colors
        private readonly Color sidebarColor = Color.FromArgb(33, 33, 46);
        private readonly Color activeColor = Color.FromArgb(0, 120, 215);
        private readonly Color hoverColor = Color.FromArgb(45, 45, 68);

        public frmMain()
        {
            InitializeComponent();
            
            // Initialize UserControls
            InitializeUserControls();
            
            // Show default view
            ShowView("Books");
        }

        private void InitializeUserControls()
        {
            ucBooksControl = new ucBooks { Dock = DockStyle.Fill };
            ucMembersControl = new ucMembers { Dock = DockStyle.Fill };
            ucLoansControl = new ucLoans { Dock = DockStyle.Fill };
            
            // Add all controls to panel but hide them initially
            panelContent.Controls.Add(ucBooksControl);
            panelContent.Controls.Add(ucMembersControl);
            panelContent.Controls.Add(ucLoansControl);
        }

        private void ShowView(string viewName)
        {
            // Update header label
            lblCurrentView.Text = viewName;
            
            // Hide current control
            if (currentControl != null)
            {
                currentControl.Visible = false;
            }
            
            // Show selected control
            switch (viewName)
            {
                case "Books":
                    ucBooksControl.Visible = true;
                    ucBooksControl.LoadBooks();
                    currentControl = ucBooksControl;
                    break;
                case "Members":
                    ucMembersControl.Visible = true;
                    ucMembersControl.LoadMembers();
                    currentControl = ucMembersControl;
                    break;
                case "Loans":
                    ucLoansControl.Visible = true;
                    ucLoansControl.LoadLoans();
                    currentControl = ucLoansControl;
                    break;
            }
        }

        private void HighlightButton(Button button)
        {
            // Reset all buttons to default color
            btnBooks.BackColor = sidebarColor;
            btnMembers.BackColor = sidebarColor;
            btnLoans.BackColor = sidebarColor;
            
            // Set active button
            button.BackColor = activeColor;
            activeButton = button;
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            HighlightButton(btnBooks);
            ShowView("Books");
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            HighlightButton(btnMembers);
            ShowView("Members");
        }

        private void btnLoans_Click(object sender, EventArgs e)
        {
            HighlightButton(btnLoans);
            ShowView("Loans");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void lblAppName_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblCurrentView_Click(object sender, EventArgs e)
        {

        }
    }
}
