using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class frmMembers : Form
    {
        private const string ConnectionString = @"Server=localhost;Database=LibraryDB;Trusted_Connection=true;Connect Timeout=30;";

        public frmMembers()
        {
            InitializeComponent();
            dgvMembers.AutoGenerateColumns = true;
            LoadMembers();
        }

        private void LoadMembers(string searchKeyword = "")
        {
            string query = @"
                SELECT 
                    MemberId,
                    FirstName,
                    LastName,
                    Email,
                    Phone,
                    JoinDate,
                    CASE WHEN IsActive = 1 THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) 
                    END AS IsActive

                FROM Members";

            if (!string.IsNullOrWhiteSpace(searchKeyword))
            {
                query += " WHERE FirstName LIKE @Search OR LastName LIKE @Search OR Email LIKE @Search";
            }

            query += " ORDER BY JoinDate DESC";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrWhiteSpace(searchKeyword))
                    {
                        command.Parameters.AddWithValue("@Search", $"%{searchKeyword}%");
                    }

                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvMembers.DataSource = dataTable;

                    // Hide MemberId column
                    if (dgvMembers.Columns.Contains("MemberId"))
                    {
                        dgvMembers.Columns["MemberId"].Visible = false;
                    }

                    // Format columns
                    if (dgvMembers.Columns.Contains("JoinDate"))
                    {
                        dgvMembers.Columns["JoinDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    }

                    dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }
        private void frmMembers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDBDataSet.Members' table. You can move, or remove it, as needed.
            this.membersTableAdapter.Fill(this.libraryDBDataSet.Members);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMembers(txtSearch.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMembers();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            var addForm = new frmMemberDetails();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadMembers(); // Refresh grid
            }
        }
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a member to edit.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvMembers.SelectedRows[0];
            var dataRowView = selectedRow.DataBoundItem as DataRowView;

            if (dataRowView != null && dataRowView.Row["MemberId"] != DBNull.Value)
            {
                int memberId = Convert.ToInt32(dataRowView.Row["MemberId"]);
                var editForm = new frmMemberDetails(memberId);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadMembers(); // Refresh
                }
            }
            else
            {
                MessageBox.Show("Invalid Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a member to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvMembers.SelectedRows[0];
            var dataRowView = selectedRow.DataBoundItem as DataRowView;

            if (dataRowView != null && dataRowView.Row["MemberId"] != DBNull.Value)
            {
                int memberId = Convert.ToInt32(dataRowView.Row["MemberId"]);

                var result = MessageBox.Show(
                    "Are you sure you want to delete this member?\nThis cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DeleteMember(memberId);
                    LoadMembers(); // Refresh
                }
            }
            else
            {
                MessageBox.Show("Invalid Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== DATABASE OPERATIONS =====

        private void DeleteMember(int memberId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Check if member has active loans
                using (var checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Loans WHERE MemberId = @MemberId AND ReturnDate IS NULL",
                    connection))
                {
                    checkCmd.Parameters.AddWithValue("@MemberId", memberId);
                    int activeLoans = (int)checkCmd.ExecuteScalar();
                    if (activeLoans > 0)
                    {
                        MessageBox.Show("Cannot delete: This member has active book loans.", "Delete Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Delete member
                using (var deleteCmd = new SqlCommand("DELETE FROM Members WHERE MemberId = @MemberId", connection))
                {
                    deleteCmd.Parameters.AddWithValue("@MemberId", memberId);
                    int rowsAffected = deleteCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Member deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Member not found or already deleted.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadMembers();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            LoadMembers(txtSearch.Text);
        }

        
    }
}
