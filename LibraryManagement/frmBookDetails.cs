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
    public partial class frmBookDetails : Form
    {
        private int? _bookId = null;

        // Constructor for ADD mode
        public frmBookDetails()
        {
            InitializeComponent();
            this.Text = "Add New Book";
            btnSave.Text = "Add Book";
        }

        private void LoadBook(int bookId)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                // Note: DBConnection.GetConnection() already opens the connection
                using (SqlCommand command = new SqlCommand(@"
                    SELECT ISBN, Title, Author, Genre, PublicationYear, CopiesTotal
                    FROM Books 
                    WHERE BookId = @BookId", connection))
                {
                    command.Parameters.AddWithValue("@BookId", bookId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtISBN.Text = reader["ISBN"] as string ?? "";
                            txtTitle.Text = reader["Title"] as string ?? "";
                            txtAuthor.Text = reader["Author"] as string ?? "";
                            txtGenre.Text = reader["Genre"] as string ?? "";

                            // Handle possible NULL year
                            if (reader["PublicationYear"] != DBNull.Value)
                                numYears.Value = Convert.ToDecimal(reader["PublicationYear"]);
                            else
                                numYears.Value = DateTime.Now.Year;

                            numCopies.Value = Convert.ToDecimal(reader["CopiesTotal"]);
                        }
                        else
                        {
                            MessageBox.Show("Book not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DialogResult = DialogResult.Cancel;
                            Close();
                        }
                    }
                }
            }
        }

        // Constructor for EDIT mode
        public frmBookDetails(int bookId) : this()
        {
            _bookId = bookId;
            this.Text = "Edit Book";
            btnSave.Text = "Update Book";
            LoadBook(bookId);
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private bool ValidateInput(out string errorMessage)
        {
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorMessage = "Title is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                errorMessage = "Author is required.";
                return false;
            }

            if (numCopies.Value < 1)
            {
                errorMessage = "Copies must be at least 1.";
                return false;
            }

            // ✅ Add year validation based on your constraint
            int year = (int)numYears.Value;
            if (year < 1900 || year > 2025) // ← Adjust to match your actual constraint!
            {
                errorMessage = "Publication Year must be between 1900 and 2025."+"You Input : "+year;
                return false;
            }

            return true;
        }
        private bool SaveBook()
        {
            if (!ValidateInput(out string error))
            {
                MessageBox.Show(error, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    // Note: DBConnection.GetConnection() already opens the connection
                    if (_bookId.HasValue)
                    {
                        // UPDATE existing book
                        using (SqlCommand command = new SqlCommand(@"
                            UPDATE Books 
                            SET ISBN = @ISBN,
                                Title = @Title,
                                Author = @Author,
                                Genre = @Genre,
                                PublicationYear = @Year,
                                CopiesTotal = @Copies,
                                CopiesAvailable = @Copies
                            WHERE BookId = @BookId", connection))
                        {
                            command.Parameters.AddWithValue("@BookId", _bookId.Value);
                            command.Parameters.AddWithValue("@ISBN", txtISBN.Text.Trim());
                            command.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                            command.Parameters.AddWithValue("@Author", txtAuthor.Text.Trim());
                            command.Parameters.AddWithValue("@Genre", txtGenre.Text.Trim());
                            command.Parameters.AddWithValue("@Year", (int)numYears.Value);
                            command.Parameters.AddWithValue("@Copies", (int)numCopies.Value);

                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("Book updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // INSERT new book
                        using (SqlCommand command = new SqlCommand(@"
                            INSERT INTO Books (ISBN, Title, Author, Genre, PublicationYear, CopiesTotal, CopiesAvailable)
                            VALUES (@ISBN, @Title, @Author, @Genre, @Year, @Copies, @Copies)", connection))
                        {
                            command.Parameters.AddWithValue("@ISBN", txtISBN.Text.Trim());
                            command.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                            command.Parameters.AddWithValue("@Author", txtAuthor.Text.Trim());
                            command.Parameters.AddWithValue("@Genre", txtGenre.Text.Trim());
                            command.Parameters.AddWithValue("@Year", (int)numYears.Value);
                            command.Parameters.AddWithValue("@Copies", (int)numCopies.Value);

                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("Book added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving:\n{ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        // ===== BUTTON CLICK HANDLERS =====
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (SaveBook())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void numYear_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
