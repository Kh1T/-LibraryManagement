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
    public partial class frmLoanNew : Form
    {
        private const string ConnectionString = @"Server=localhost;Database=LibraryDB;Trusted_Connection=true;Connect Timeout=30;";

        public frmLoanNew()
        {
            InitializeComponent();
            LoadBooks();
            LoadMembers();
            dtpBorrowDate.Value = DateTime.Today;
            dtpDueDate.Value = DateTime.Today.AddDays(14); // Default 2 weeks
        }
        private void LoadBooks()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_GetAvailableBooks", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    cmbBook.DisplayMember = "Title";
                    cmbBook.ValueMember = "BookId";
                    cmbBook.DataSource = dataTable;
                }
            }
        }
        private void LoadMembers()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("sp_GetActiveMembers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    cmbMember.DisplayMember = "FullName";
                    cmbMember.ValueMember = "MemberId";
                    cmbMember.DataSource = dataTable;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                CreateLoan();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating loan: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateLoan()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand("sp_CreateLoan", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BookId", cmbBook.SelectedValue);
                        command.Parameters.AddWithValue("@MemberId", cmbMember.SelectedValue);
                        command.Parameters.AddWithValue("@BorrowDate", dtpBorrowDate.Value);
                        command.Parameters.AddWithValue("@DueDate", dtpDueDate.Value);

                        var newLoanIdParam = new SqlParameter("@NewLoanId", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        var resultMessageParam = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 255)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(newLoanIdParam);
                        command.Parameters.Add(resultMessageParam);

                        // Use ExecuteNonQuery for stored procedures with OUTPUT parameters
                        command.ExecuteNonQuery();

                        // Read the OUTPUT parameters after execution
                        int newLoanId = newLoanIdParam.Value != DBNull.Value ? Convert.ToInt32(newLoanIdParam.Value) : 0;
                        string resultMessage = resultMessageParam.Value?.ToString() ?? "Unknown error";

                        if (newLoanId > 0)
                        {
                            MessageBox.Show($"Loan created successfully! Loan ID: {newLoanId}", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            throw new Exception(resultMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create loan: {ex.Message}");
            }
        }

        private bool ValidateForm()
        {
            if (cmbBook.SelectedValue == null)
            {
                MessageBox.Show("Please select a book.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBook.Focus();
                return false;
            }

            if (cmbMember.SelectedValue == null)
            {
                MessageBox.Show("Please select a member.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMember.Focus();
                return false;
            }

            if (dtpDueDate.Value <= dtpBorrowDate.Value)
            {
                MessageBox.Show("Due date must be after borrow date.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDueDate.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show book details when selected
            if (cmbBook.SelectedValue != null)
            {
                // You can display additional book info here
            }
        }
    }
}
