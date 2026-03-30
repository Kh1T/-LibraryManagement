// Forms/BooksForm.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryManagement.Forms
{
    public partial class frmBooks : Form
    {
        private const string ConnectionString = @"Server=localhost;Database=LibraryDB;Trusted_Connection=true;Connect Timeout=30;";
        public frmBooks()
        {
            InitializeComponent();
            this.Text = "📚 Book Management";
            dgvBooks.AutoGenerateColumns = true;
            LoadBooks();
        }

        // Load all books into DataGridView
        private void LoadBooks(string searchKeyword = "")
        {
            string query = @"
        SELECT 
            BookId,
            ISBN,
            Title,
            Author,
            Genre,
            PublicationYear,
            CopiesTotal,
            CopiesAvailable,
            CASE 
                WHEN CopiesAvailable > 0 THEN 'Available'
                ELSE 'On Loan'
            END AS Status
        FROM Books";

            if (!string.IsNullOrWhiteSpace(searchKeyword))
            {
                query += " WHERE Title LIKE @Search OR Author LIKE @Search";
            }

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

                    dgvBooks.DataSource = dataTable;

                    if (dgvBooks.Columns.Contains("BookId"))
                    {
                        dgvBooks.Columns["BookId"].Visible = false;
                    }

                    dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }

        // ===== BUTTON HANDLERS =====

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            LoadBooks(txtSearch.Text);
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            var addForm = new frmBookDetails();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadBooks(); // Refresh grid
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to edit.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvBooks.SelectedRows[0];
            var dataRowView = selectedRow.DataBoundItem as DataRowView;

            if (dataRowView != null && dataRowView.Row["BookId"] != DBNull.Value)
            {
                int bookId = Convert.ToInt32(dataRowView.Row["BookId"]);
                var editForm = new frmBookDetails(bookId);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadBooks(); // Refresh
                }
            }
            else
            {
                MessageBox.Show("Invalid Book ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvBooks.SelectedRows[0];
            var dataRowView = selectedRow.DataBoundItem as DataRowView;

            if (dataRowView != null && dataRowView.Row["BookId"] != DBNull.Value)
            {
                int bookId = Convert.ToInt32(dataRowView.Row["BookId"]);

                var result = MessageBox.Show(
                    "Are you sure you want to delete this book?\nThis cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DeleteBook(bookId);
                    LoadBooks(); // Refresh
                }
            }
            else
            {
                MessageBox.Show("Invalid Book ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== DATABASE OPERATIONS =====

        private void DeleteBook(int bookId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Check if book is on loan
                using (var checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Loans WHERE BookId = @BookId AND ReturnDate IS NULL",
                    connection))
                {
                    checkCmd.Parameters.AddWithValue("@BookId", bookId);
                    int activeLoans = (int)checkCmd.ExecuteScalar();
                    if (activeLoans > 0)
                    {
                        MessageBox.Show("Cannot delete: This book is currently on loan.", "Delete Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                using (var deleteCmd = new SqlCommand("DELETE FROM Books WHERE BookId = @BookId", connection))
                {
                    deleteCmd.Parameters.AddWithValue("@BookId", bookId);
                    deleteCmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Book deleted successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BooksForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDBDataSet.Books' table. You can move, or remove it, as needed.
            //this.booksTableAdapter.Fill(this.libraryDBDataSet.Books);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}