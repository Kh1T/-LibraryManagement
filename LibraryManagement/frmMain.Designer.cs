namespace LibraryManagement.Forms
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblAppName = new System.Windows.Forms.Label();
            this.panelNavButtons = new System.Windows.Forms.Panel();
            this.btnLoans = new System.Windows.Forms.Button();
            this.btnMembers = new System.Windows.Forms.Button();
            this.btnBooks = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblCurrentView = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            this.panelNavButtons.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.panelSidebar.Controls.Add(this.textBox1);
            this.panelSidebar.Controls.Add(this.pictureBox1);
            this.panelSidebar.Controls.Add(this.lblAppName);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.panelNavButtons);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(367, 1000);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(30, 892);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(307, 69);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblAppName
            // 
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAppName.Location = new System.Drawing.Point(126, 23);
            this.lblAppName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(233, 99);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "Beltie University\r\nLibrary System";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAppName.Click += new System.EventHandler(this.lblAppName_Click);
            // 
            // panelNavButtons
            // 
            this.panelNavButtons.Controls.Add(this.btnLoans);
            this.panelNavButtons.Controls.Add(this.btnMembers);
            this.panelNavButtons.Controls.Add(this.btnBooks);
            this.panelNavButtons.Location = new System.Drawing.Point(0, 175);
            this.panelNavButtons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelNavButtons.Name = "panelNavButtons";
            this.panelNavButtons.Size = new System.Drawing.Size(367, 385);
            this.panelNavButtons.TabIndex = 2;
            // 
            // btnLoans
            // 
            this.btnLoans.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.btnLoans.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoans.FlatAppearance.BorderSize = 0;
            this.btnLoans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoans.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnLoans.ForeColor = System.Drawing.Color.White;
            this.btnLoans.Location = new System.Drawing.Point(0, 122);
            this.btnLoans.Margin = new System.Windows.Forms.Padding(14, 5, 4, 5);
            this.btnLoans.Name = "btnLoans";
            this.btnLoans.Size = new System.Drawing.Size(367, 61);
            this.btnLoans.TabIndex = 2;
            this.btnLoans.Text = "🫳 Loans";
            this.btnLoans.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoans.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoans.UseVisualStyleBackColor = false;
            this.btnLoans.Click += new System.EventHandler(this.btnLoans_Click);
            // 
            // btnMembers
            // 
            this.btnMembers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.btnMembers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMembers.FlatAppearance.BorderSize = 0;
            this.btnMembers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMembers.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMembers.ForeColor = System.Drawing.Color.White;
            this.btnMembers.Location = new System.Drawing.Point(0, 61);
            this.btnMembers.Margin = new System.Windows.Forms.Padding(14, 5, 4, 5);
            this.btnMembers.Name = "btnMembers";
            this.btnMembers.Size = new System.Drawing.Size(367, 61);
            this.btnMembers.TabIndex = 1;
            this.btnMembers.Text = "👥 Members";
            this.btnMembers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMembers.UseVisualStyleBackColor = false;
            this.btnMembers.Click += new System.EventHandler(this.btnMembers_Click);
            // 
            // btnBooks
            // 
            this.btnBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnBooks.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBooks.FlatAppearance.BorderSize = 0;
            this.btnBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBooks.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnBooks.ForeColor = System.Drawing.Color.White;
            this.btnBooks.Location = new System.Drawing.Point(0, 0);
            this.btnBooks.Margin = new System.Windows.Forms.Padding(14, 5, 4, 5);
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.Size = new System.Drawing.Size(367, 61);
            this.btnBooks.TabIndex = 0;
            this.btnBooks.Text = "📚 Books";
            this.btnBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBooks.UseVisualStyleBackColor = false;
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.panelHeader.Controls.Add(this.lblCurrentView);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(367, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1133, 112);
            this.panelHeader.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(367, 112);
            this.panelContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1133, 888);
            this.panelContent.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(19, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.textBox1.Location = new System.Drawing.Point(133, 125);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(217, 15);
            this.textBox1.TabIndex = 3;
            // 
            // lblCurrentView
            // 
            this.lblCurrentView.AutoSize = true;
            this.lblCurrentView.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblCurrentView.Location = new System.Drawing.Point(21, 47);
            this.lblCurrentView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentView.Name = "lblCurrentView";
            this.lblCurrentView.Size = new System.Drawing.Size(165, 65);
            this.lblCurrentView.TabIndex = 0;
            this.lblCurrentView.Text = "Books";
            this.lblCurrentView.Click += new System.EventHandler(this.lblCurrentView_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 1000);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Management System";
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panelNavButtons.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelNavButtons;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button btnBooks;
        private System.Windows.Forms.Button btnMembers;
        private System.Windows.Forms.Button btnLoans;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblCurrentView;
    }
}
