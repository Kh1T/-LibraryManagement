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
    public partial class frmLoan : Form
    {
        private const string ConnectionString = @"Server=localhost;Database=LibraryDB;Trusted_Connection=true;Connect Timeout=30;";
        public frmLoan()
        {
            InitializeComponent();
            dgvLoans.AutoGenerateColumns = true;
            LoadLoans();
            SetupFilterComboBox();
        }

        // Load all loans into DataGridView using stored procedure
        private void LoadLoans(string filter = "All")
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("sp_GetLoans", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Filter", filter);
                    command.Parameters.AddWithValue("@Search", string.IsNullOrWhiteSpace(txtSearch.Text) ? (object)DBNull.Value : txtSearch.Text);

                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvLoans.DataSource = dataTable;

                    // Hide ID columns
                    if (dgvLoans.Columns.Contains("LoanId"))
                        dgvLoans.Columns["LoanId"].Visible = false;
                    if (dgvLoans.Columns.Contains("BookId"))
                        dgvLoans.Columns["BookId"].Visible = false;
                    if (dgvLoans.Columns.Contains("MemberId"))
                        dgvLoans.Columns["MemberId"].Visible = false;

                    // Format date columns
                    if (dgvLoans.Columns.Contains("BorrowDate"))
                        dgvLoans.Columns["BorrowDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    if (dgvLoans.Columns.Contains("DueDate"))
                        dgvLoans.Columns["DueDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    if (dgvLoans.Columns.Contains("ReturnDate"))
                        dgvLoans.Columns["ReturnDate"].DefaultCellStyle.Format = "yyyy-MM-dd";

                    dgvLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Color code overdue loans
                    foreach (DataGridViewRow row in dgvLoans.Rows)
                    {
                        if (row.Cells["Status"].Value?.ToString() == "Overdue")
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                        }
                        else if (row.Cells["Status"].Value?.ToString() == "Returned")
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                        }
                    }
                }
            }
        }

        private void SetupFilterComboBox()
        {
            cmbFilter.Items.AddRange(new string[] { "All", "Active", "Overdue", "Returned" });
            cmbFilter.SelectedIndex = 0;
        }

        private void frmLoan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDBDataSet.Loans' table. You can move, or remove it, as needed.
            this.loansTableAdapter.Fill(this.libraryDBDataSet.Loans);

        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // ===== BUTTON HANDLERS =====
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadLoans(cmbFilter.SelectedItem?.ToString() ?? "All");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLoans(cmbFilter.SelectedItem?.ToString() ?? "All");
        }

        private void btnNewLoan_Click(object sender, EventArgs e)
        {
            var newLoanForm = new frmLoanNew();
            if (newLoanForm.ShowDialog() == DialogResult.OK)
            {
                LoadLoans(); // Refresh grid
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvLoans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a loan to return.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvLoans.SelectedRows[0];
            var dataRowView = selectedRow.DataBoundItem as DataRowView;

            if (dataRowView != null && dataRowView.Row["LoanId"] != DBNull.Value)
            {
                int loanId = Convert.ToInt32(dataRowView.Row["LoanId"]);

                // Check if already returned
                if (dataRowView.Row["ReturnDate"] != DBNull.Value)
                {
                    MessageBox.Show("This book has already been returned.", "Already Returned",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var result = MessageBox.Show(
                    "Mark this book as returned?",
                    "Confirm Return",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ReturnBook(loanId);
                    LoadLoans(); // Refresh
                }
            }
            else
            {
                MessageBox.Show("Invalid Loan selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExtend_Click_1(object sender, EventArgs e)
        {
            if (dgvLoans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a loan to extend.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvLoans.SelectedRows[0];
            var dataRowView = selectedRow.DataBoundItem as DataRowView;

            if (dataRowView != null && dataRowView.Row["LoanId"] != DBNull.Value)
            {
                int loanId = Convert.ToInt32(dataRowView.Row["LoanId"]);

                // Check if already returned
                if (dataRowView.Row["ReturnDate"] != DBNull.Value)
                {
                    MessageBox.Show("Cannot extend: This book has already been returned.", "Already Returned",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ExtendDueDate(loanId);
                LoadLoans(); // Refresh
            }
            else
            {
                MessageBox.Show("Invalid Loan selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== DATABASE OPERATIONS =====

        private void ReturnBook(int loanId)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    
                    using (var command = new SqlCommand("sp_ReturnBook", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@LoanId", loanId);
                        command.Parameters.AddWithValue("@ReturnDate", DateTime.Today);
                        
                        var resultParam = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 255)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(resultParam);

                        int returnValue = (int)command.ExecuteScalar();

                        if (returnValue == 0)
                        {
                            MessageBox.Show("Book returned successfully.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(resultParam.Value.ToString(), "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error returning book: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExtendDueDate(int loanId)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    
                    using (var command = new SqlCommand("sp_ExtendDueDate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@LoanId", loanId);
                        command.Parameters.AddWithValue("@ExtensionDays", 14);
                        
                        var resultParam = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 255)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(resultParam);

                        int returnValue = (int)command.ExecuteScalar();

                        if (returnValue == 0)
                        {
                            MessageBox.Show("Due date extended by 14 days.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(resultParam.Value.ToString(), "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error extending due date: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== FORM EVENTS =====

        private void frmLoans_Load(object sender, EventArgs e)
        {
            // Additional initialization if needed
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLoans(cmbFilter.SelectedItem?.ToString() ?? "All");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Optional: Auto-search with delay
        }

        private void dgvLoans_SelectionChanged(object sender, EventArgs e)
        {
            // Update button states based on selection
            if (dgvLoans.SelectedRows.Count > 0)
            {
                var selectedRow = dgvLoans.SelectedRows[0];
                var dataRowView = selectedRow.DataBoundItem as DataRowView;

                bool isReturned = dataRowView?.Row["ReturnDate"] != DBNull.Value;
                btnReturn.Enabled = !isReturned;
                btnExtend.Enabled = !isReturned;
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
