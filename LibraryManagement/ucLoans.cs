using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryManagement.Forms
{
    public partial class ucLoans : UserControl
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnNewLoan;
        private Button btnReturn;
        private Button btnExtend;
        private Button btnRefresh;
        private Button btnSearch;
        private DataGridView dgvLoans;
        private TextBox txtSearch;
        private ComboBox cmbFilter;

        public ucLoans()
        {
            InitializeComponent();
            dgvLoans.AutoGenerateColumns = true;
            SetupFilterComboBox();
            LoadLoans();
        }

        private void InitializeComponent()
        {
            this.btnNewLoan = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnExtend = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvLoans = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNewLoan
            // 
            this.btnNewLoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnNewLoan.FlatAppearance.BorderSize = 0;
            this.btnNewLoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewLoan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewLoan.ForeColor = System.Drawing.Color.White;
            this.btnNewLoan.Location = new System.Drawing.Point(693, 91);
            this.btnNewLoan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNewLoan.Name = "btnNewLoan";
            this.btnNewLoan.Size = new System.Drawing.Size(122, 49);
            this.btnNewLoan.TabIndex = 0;
            this.btnNewLoan.Text = "New Loan";
            this.btnNewLoan.UseVisualStyleBackColor = false;
            this.btnNewLoan.Click += new System.EventHandler(this.btnNewLoan_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Location = new System.Drawing.Point(823, 91);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(135, 49);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnExtend
            // 
            this.btnExtend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnExtend.FlatAppearance.BorderSize = 0;
            this.btnExtend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtend.ForeColor = System.Drawing.Color.Black;
            this.btnExtend.Location = new System.Drawing.Point(966, 91);
            this.btnExtend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExtend.Name = "btnExtend";
            this.btnExtend.Size = new System.Drawing.Size(135, 49);
            this.btnExtend.TabIndex = 2;
            this.btnExtend.Text = "Extend";
            this.btnExtend.UseVisualStyleBackColor = false;
            this.btnExtend.Click += new System.EventHandler(this.btnExtend_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(570, 91);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(115, 49);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(427, 91);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(135, 49);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvLoans
            // 
            this.dgvLoans.AllowUserToAddRows = false;
            this.dgvLoans.AllowUserToDeleteRows = false;
            this.dgvLoans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoans.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoans.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvLoans.Location = new System.Drawing.Point(0, 188);
            this.dgvLoans.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLoans.Name = "dgvLoans";
            this.dgvLoans.ReadOnly = true;
            this.dgvLoans.RowHeadersWidth = 62;
            this.dgvLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoans.Size = new System.Drawing.Size(1120, 662);
            this.dgvLoans.TabIndex = 5;
            this.dgvLoans.SelectionChanged += new System.EventHandler(this.dgvLoans_SelectionChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(30, 98);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(389, 34);
            this.txtSearch.TabIndex = 6;
            // 
            // cmbFilter
            // 
            this.cmbFilter.BackColor = System.Drawing.Color.White;
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(30, 98);
            this.cmbFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(388, 33);
            this.cmbFilter.TabIndex = 7;
            this.cmbFilter.Visible = false;
            // 
            // ucLoans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvLoans);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnExtend);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnNewLoan);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucLoans";
            this.Size = new System.Drawing.Size(1120, 850);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void SetupFilterComboBox()
        {
            cmbFilter.Items.AddRange(new string[] { "All", "Active", "Overdue", "Returned" });
            cmbFilter.SelectedIndex = 0;
        }

        public void LoadLoans(string filter = "All")
        {
            using (var connection = DBConnection.GetConnection())
            {
                using (var command = new SqlCommand("sp_GetLoans", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Filter", filter);
                    command.Parameters.AddWithValue("@Search", string.IsNullOrWhiteSpace(txtSearch.Text) ? (object)DBNull.Value : txtSearch.Text);

                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvLoans.DataSource = dataTable;

                    if (dgvLoans.Columns.Contains("LoanId"))
                        dgvLoans.Columns["LoanId"].Visible = false;
                    if (dgvLoans.Columns.Contains("BookId"))
                        dgvLoans.Columns["BookId"].Visible = false;
                    if (dgvLoans.Columns.Contains("MemberId"))
                        dgvLoans.Columns["MemberId"].Visible = false;

                    if (dgvLoans.Columns.Contains("BorrowDate"))
                        dgvLoans.Columns["BorrowDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    if (dgvLoans.Columns.Contains("DueDate"))
                        dgvLoans.Columns["DueDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    if (dgvLoans.Columns.Contains("ReturnDate"))
                        dgvLoans.Columns["ReturnDate"].DefaultCellStyle.Format = "yyyy-MM-dd";

                    dgvLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadLoans(cmbFilter.SelectedItem?.ToString() ?? "All");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadLoans(cmbFilter.SelectedItem?.ToString() ?? "All");
        }

        private void btnNewLoan_Click(object sender, EventArgs e)
        {
            var newLoanForm = new frmLoanNew();
            if (newLoanForm.ShowDialog() == DialogResult.OK)
            {
                LoadLoans();
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
                    LoadLoans();
                }
            }
            else
            {
                MessageBox.Show("Invalid Loan selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExtend_Click(object sender, EventArgs e)
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

                if (dataRowView.Row["ReturnDate"] != DBNull.Value)
                {
                    MessageBox.Show("Cannot extend: This book has already been returned.", "Already Returned",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ExtendDueDate(loanId);
                LoadLoans();
            }
            else
            {
                MessageBox.Show("Invalid Loan selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReturnBook(int loanId)
        {
            try
            {
                using (var connection = DBConnection.GetConnection())
                {
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

                        command.ExecuteNonQuery();

                        string resultMessage = resultParam.Value?.ToString() ?? "Unknown error";

                        MessageBox.Show(resultMessage, "Result",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error returning book: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExtendDueDate(int loanId)
        {
            try
            {
                using (var connection = DBConnection.GetConnection())
                {
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

                        command.ExecuteNonQuery();

                        string resultMessage = resultParam.Value?.ToString() ?? "Unknown error";

                        MessageBox.Show(resultMessage, "Result",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error extending due date: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLoans_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLoans.SelectedRows.Count > 0)
            {
                var selectedRow = dgvLoans.SelectedRows[0];
                var dataRowView = selectedRow.DataBoundItem as DataRowView;

                bool isReturned = dataRowView?.Row["ReturnDate"] != DBNull.Value;
                btnReturn.Enabled = !isReturned;
                btnExtend.Enabled = !isReturned;
            }
        }
    }
}
