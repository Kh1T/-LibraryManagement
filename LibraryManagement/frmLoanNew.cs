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
            string query = @"
                SELECT BookId, Title, Author, CopiesAvailable 
                FROM Books 
                WHERE CopiesAvailable > 0
                ORDER BY Title";

            using (var connection = new SqlConnection(ConnectionString))
            {
                var adapter = new SqlDataAdapter(query, connection);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);

                cmbBook.DisplayMember = "Title";
                cmbBook.ValueMember = "BookId";
                cmbBook.DataSource = dataTable;
            }
        }
        private void LoadMembers()
        {
            string query = @"
                SELECT MemberId, FirstName + ' ' + LastName AS FullName 
                FROM Members 
                WHERE IsActive = 1
                ORDER BY LastName, FirstName";

            using (var connection = new SqlConnection(ConnectionString))
            {
                var adapter = new SqlDataAdapter(query, connection);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);

                cmbMember.DisplayMember = "FullName";
                cmbMember.ValueMember = "MemberId";
                cmbMember.DataSource = dataTable;
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
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Create loan record
                        using (var loanCmd = new SqlCommand(
                            "INSERT INTO Loans (BookId, MemberId, BorrowDate, DueDate) VALUES (@BookId, @MemberId, @BorrowDate, @DueDate)",
                            connection, transaction))
                        {
                            loanCmd.Parameters.AddWithValue("@BookId", cmbBook.SelectedValue);
                            loanCmd.Parameters.AddWithValue("@MemberId", cmbMember.SelectedValue);
                            loanCmd.Parameters.AddWithValue("@BorrowDate", dtpBorrowDate.Value);
                            loanCmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value);
                            loanCmd.ExecuteNonQuery();
                        }

                        // Decrease available copies
                        using (var updateCmd = new SqlCommand(
                            "UPDATE Books SET CopiesAvailable = CopiesAvailable - 1 WHERE BookId = @BookId",
                            connection, transaction))
                        {
                            updateCmd.Parameters.AddWithValue("@BookId", cmbBook.SelectedValue);
                            updateCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Book loan created successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Failed to create loan: {ex.Message}");
                    }
                }
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
