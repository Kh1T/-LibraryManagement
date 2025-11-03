using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibraryManagement
{
    public partial class frmMemberDetails : Form
    {
        private const string ConnectionString = @"Server=localhost;Database=LibraryDB;Trusted_Connection=true;Connect Timeout=30;";
        private int _memberId = -1;
        public frmMemberDetails()
        {
            InitializeComponent();
            //InitializeForm();
        }

        public frmMemberDetails(int memberId)
        {
            InitializeComponent();
            _memberId = memberId;
            InitializeForm();
            LoadMemberData();
        }

        private void InitializeForm()
        {
            dtpJoinDate.Value = DateTime.Today;
            chkActive.Checked = true;
        }

        private void LoadMemberData()
        {
            if (_memberId <= 0) return;

            string query = "SELECT FirstName, LastName, Email, Phone, JoinDate, IsActive FROM Members WHERE MemberId = @MemberId";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MemberId", _memberId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFirstName.Text = reader["FirstName"].ToString();
                            txtLastName.Text = reader["LastName"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtPhone.Text = reader["Phone"]?.ToString() ?? "";
                            dtpJoinDate.Value = Convert.ToDateTime(reader["JoinDate"]);
                            chkActive.Checked = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                if (_memberId <= 0)
                {
                    InsertMember();
                }
                else
                {
                    UpdateMember();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving member: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsertMember()
        {
            string query = @"
                INSERT INTO Members (FirstName, LastName, Email, Phone, JoinDate, IsActive)
                VALUES (@FirstName, @LastName, @Email, @Phone, @JoinDate, @IsActive)";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    SetParameters(command);
                    command.ExecuteNonQuery();
                }
            }
        }
        private void UpdateMember()
        {
            string query = @"
                UPDATE Members 
                SET FirstName = @FirstName, 
                    LastName = @LastName, 
                    Email = @Email, 
                    Phone = @Phone, 
                    JoinDate = @JoinDate, 
                    IsActive = @IsActive
                WHERE MemberId = @MemberId";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    SetParameters(command);
                    command.Parameters.AddWithValue("@MemberId", _memberId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void SetParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
            command.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
            command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            command.Parameters.AddWithValue("@Phone", string.IsNullOrWhiteSpace(txtPhone.Text) ? DBNull.Value : (object)txtPhone.Text.Trim());
            command.Parameters.AddWithValue("@JoinDate", dtpJoinDate.Value);
            command.Parameters.AddWithValue("@IsActive", chkActive.Checked);
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Please enter first name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter last name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Basic email validation
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
