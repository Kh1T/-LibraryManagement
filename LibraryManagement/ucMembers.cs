using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryManagement.Forms
{
    public partial class ucMembers : UserControl
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnSearch;
        private DataGridView dgvMembers;
        private TextBox txtSearch;

        public ucMembers()
        {
            InitializeComponent();
            dgvMembers.AutoGenerateColumns = true;
            LoadMembers();
        }

        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(773, 91);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(115, 49);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(896, 91);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(91, 49);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(995, 91);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 49);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(522, 91);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(121, 49);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(651, 91);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(114, 49);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvMembers
            // 
            this.dgvMembers.AllowUserToAddRows = false;
            this.dgvMembers.AllowUserToDeleteRows = false;
            this.dgvMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMembers.BackgroundColor = System.Drawing.Color.White;
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvMembers.Location = new System.Drawing.Point(0, 188);
            this.dgvMembers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.ReadOnly = true;
            this.dgvMembers.RowHeadersWidth = 62;
            this.dgvMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.Size = new System.Drawing.Size(1120, 662);
            this.dgvMembers.TabIndex = 5;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(30, 98);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(449, 34);
            this.txtSearch.TabIndex = 6;
            // 
            // ucMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvMembers);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucMembers";
            this.Size = new System.Drawing.Size(1120, 850);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
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

        public void LoadMembers(string searchKeyword = "")
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

            using (var connection = DBConnection.GetConnection())
            {
                using (var command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrWhiteSpace(searchKeyword))
                    {
                        command.Parameters.AddWithValue("@Search", "%" + searchKeyword + "%");
                    }

                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvMembers.DataSource = dataTable;

                    if (dgvMembers.Columns.Contains("MemberId"))
                    {
                        dgvMembers.Columns["MemberId"].Visible = false;
                    }

                    if (dgvMembers.Columns.Contains("JoinDate"))
                    {
                        dgvMembers.Columns["JoinDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    }

                    dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMembers(txtSearch.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadMembers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new frmMemberDetails();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadMembers();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
                    LoadMembers();
                }
            }
            else
            {
                MessageBox.Show("Invalid Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
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
                    LoadMembers();
                }
            }
            else
            {
                MessageBox.Show("Invalid Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteMember(int memberId)
        {
            using (var connection = DBConnection.GetConnection())
            {
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
    }
}
