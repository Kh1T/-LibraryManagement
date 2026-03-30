namespace LibraryManagement
{
    partial class frmLoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvLoans = new System.Windows.Forms.DataGridView();
            this.loanIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memberIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrowDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dueDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loansBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.libraryDBDataSet = new LibraryManagement.LibraryDBDataSet();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnNewLoan = new System.Windows.Forms.Button();
            this.btnExtend = new System.Windows.Forms.Button();
            this.loansTableAdapter = new LibraryManagement.LibraryDBDataSetTableAdapters.LoansTableAdapter();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loansBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLoans
            // 
            this.dgvLoans.AutoGenerateColumns = false;
            this.dgvLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.loanIdDataGridViewTextBoxColumn,
            this.bookIdDataGridViewTextBoxColumn,
            this.memberIdDataGridViewTextBoxColumn,
            this.borrowDateDataGridViewTextBoxColumn,
            this.dueDateDataGridViewTextBoxColumn,
            this.returnDateDataGridViewTextBoxColumn});
            this.dgvLoans.DataSource = this.loansBindingSource;
            this.dgvLoans.Location = new System.Drawing.Point(45, 189);
            this.dgvLoans.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLoans.Name = "dgvLoans";
            this.dgvLoans.RowHeadersWidth = 62;
            this.dgvLoans.Size = new System.Drawing.Size(1109, 351);
            this.dgvLoans.TabIndex = 13;
            // 
            // loanIdDataGridViewTextBoxColumn
            // 
            this.loanIdDataGridViewTextBoxColumn.DataPropertyName = "LoanId";
            this.loanIdDataGridViewTextBoxColumn.HeaderText = "LoanId";
            this.loanIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.loanIdDataGridViewTextBoxColumn.Name = "loanIdDataGridViewTextBoxColumn";
            this.loanIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.loanIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // bookIdDataGridViewTextBoxColumn
            // 
            this.bookIdDataGridViewTextBoxColumn.DataPropertyName = "BookId";
            this.bookIdDataGridViewTextBoxColumn.HeaderText = "BookId";
            this.bookIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.bookIdDataGridViewTextBoxColumn.Name = "bookIdDataGridViewTextBoxColumn";
            this.bookIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // memberIdDataGridViewTextBoxColumn
            // 
            this.memberIdDataGridViewTextBoxColumn.DataPropertyName = "MemberId";
            this.memberIdDataGridViewTextBoxColumn.HeaderText = "MemberId";
            this.memberIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.memberIdDataGridViewTextBoxColumn.Name = "memberIdDataGridViewTextBoxColumn";
            this.memberIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // borrowDateDataGridViewTextBoxColumn
            // 
            this.borrowDateDataGridViewTextBoxColumn.DataPropertyName = "BorrowDate";
            this.borrowDateDataGridViewTextBoxColumn.HeaderText = "BorrowDate";
            this.borrowDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.borrowDateDataGridViewTextBoxColumn.Name = "borrowDateDataGridViewTextBoxColumn";
            this.borrowDateDataGridViewTextBoxColumn.Width = 150;
            // 
            // dueDateDataGridViewTextBoxColumn
            // 
            this.dueDateDataGridViewTextBoxColumn.DataPropertyName = "DueDate";
            this.dueDateDataGridViewTextBoxColumn.HeaderText = "DueDate";
            this.dueDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.dueDateDataGridViewTextBoxColumn.Name = "dueDateDataGridViewTextBoxColumn";
            this.dueDateDataGridViewTextBoxColumn.Width = 150;
            // 
            // returnDateDataGridViewTextBoxColumn
            // 
            this.returnDateDataGridViewTextBoxColumn.DataPropertyName = "ReturnDate";
            this.returnDateDataGridViewTextBoxColumn.HeaderText = "ReturnDate";
            this.returnDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.returnDateDataGridViewTextBoxColumn.Name = "returnDateDataGridViewTextBoxColumn";
            this.returnDateDataGridViewTextBoxColumn.Width = 150;
            // 
            // loansBindingSource
            // 
            this.loansBindingSource.DataMember = "Loans";
            this.loansBindingSource.DataSource = this.libraryDBDataSet;
            // 
            // libraryDBDataSet
            // 
            this.libraryDBDataSet.DataSetName = "LibraryDBDataSet";
            this.libraryDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(678, 100);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 35);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(270, 105);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 35);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(921, 98);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(112, 35);
            this.btnReturn.TabIndex = 10;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnNewLoan
            // 
            this.btnNewLoan.Location = new System.Drawing.Point(800, 100);
            this.btnNewLoan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNewLoan.Name = "btnNewLoan";
            this.btnNewLoan.Size = new System.Drawing.Size(112, 35);
            this.btnNewLoan.TabIndex = 9;
            this.btnNewLoan.Text = "New Loan";
            this.btnNewLoan.UseVisualStyleBackColor = true;
            this.btnNewLoan.Click += new System.EventHandler(this.btnNewLoan_Click);
            // 
            // btnExtend
            // 
            this.btnExtend.Location = new System.Drawing.Point(1042, 100);
            this.btnExtend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExtend.Name = "btnExtend";
            this.btnExtend.Size = new System.Drawing.Size(112, 35);
            this.btnExtend.TabIndex = 8;
            this.btnExtend.Text = "Extend";
            this.btnExtend.UseVisualStyleBackColor = true;
            this.btnExtend.Click += new System.EventHandler(this.btnExtend_Click_1);
            // 
            // loansTableAdapter
            // 
            this.loansTableAdapter.ClearBeforeFill = true;
            // 
            // cmbFilter
            // 
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(45, 109);
            this.cmbFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(180, 28);
            this.cmbFilter.TabIndex = 15;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(61, 57);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(32, 26);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.Visible = false;
            // 
            // frmLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvLoans);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnNewLoan);
            this.Controls.Add(this.btnExtend);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLoan";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loansBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvLoans;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnNewLoan;
        private System.Windows.Forms.Button btnExtend;
        private LibraryDBDataSet libraryDBDataSet;
        private System.Windows.Forms.BindingSource loansBindingSource;
        private LibraryDBDataSetTableAdapters.LoansTableAdapter loansTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memberIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrowDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dueDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.TextBox txtSearch;
    }
}