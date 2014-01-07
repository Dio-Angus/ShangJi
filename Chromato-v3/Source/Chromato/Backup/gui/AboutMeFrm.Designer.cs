namespace Chromato.gui
{
    partial class AboutMeFrm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.assembliesListView = new System.Windows.Forms.ListView();
            this.assemblyColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.versionColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.dateColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.companyNameColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.descriptionColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.rtbHelp = new System.Windows.Forms.RichTextBox();
            this.lnkHomePage = new System.Windows.Forms.LinkLabel();
            this.lnkAuthorEmail = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(590, 313);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // assembliesListView
            // 
            this.assembliesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.assembliesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.assemblyColumnHeader,
            this.versionColumnHeader,
            this.dateColumnHeader,
            this.companyNameColumnHeader,
            this.descriptionColumnHeader});
            this.assembliesListView.Location = new System.Drawing.Point(244, 65);
            this.assembliesListView.Name = "assembliesListView";
            this.assembliesListView.Size = new System.Drawing.Size(428, 194);
            this.assembliesListView.TabIndex = 1;
            this.assembliesListView.UseCompatibleStateImageBehavior = false;
            this.assembliesListView.View = System.Windows.Forms.View.Details;
            this.assembliesListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.assembliesListView_ColumnClick);
            // 
            // assemblyColumnHeader
            // 
            this.assemblyColumnHeader.Text = "Module";
            this.assemblyColumnHeader.Width = 106;
            // 
            // versionColumnHeader
            // 
            this.versionColumnHeader.Text = "Version";
            this.versionColumnHeader.Width = 100;
            // 
            // dateColumnHeader
            // 
            this.dateColumnHeader.Text = "Date";
            this.dateColumnHeader.Width = 79;
            // 
            // companyNameColumnHeader
            // 
            this.companyNameColumnHeader.Text = "CompanyName";
            this.companyNameColumnHeader.Width = 136;
            // 
            // descriptionColumnHeader
            // 
            this.descriptionColumnHeader.Text = "Description";
            this.descriptionColumnHeader.Width = 146;
            // 
            // rtbHelp
            // 
            this.rtbHelp.BackColor = System.Drawing.SystemColors.Control;
            this.rtbHelp.Location = new System.Drawing.Point(4, 2);
            this.rtbHelp.Name = "rtbHelp";
            this.rtbHelp.ReadOnly = true;
            this.rtbHelp.Size = new System.Drawing.Size(236, 336);
            this.rtbHelp.TabIndex = 3;
            this.rtbHelp.Text = "This Project main function is ";
            // 
            // lnkHomePage
            // 
            this.lnkHomePage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkHomePage.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkHomePage.Location = new System.Drawing.Point(242, 292);
            this.lnkHomePage.Name = "lnkHomePage";
            this.lnkHomePage.Size = new System.Drawing.Size(326, 17);
            this.lnkHomePage.TabIndex = 6;
            this.lnkHomePage.TabStop = true;
            this.lnkHomePage.Text = "产品主页: http://www.sict.stc.sh.cn/";
            // 
            // lnkAuthorEmail
            // 
            this.lnkAuthorEmail.AutoSize = true;
            this.lnkAuthorEmail.Location = new System.Drawing.Point(306, 315);
            this.lnkAuthorEmail.Name = "lnkAuthorEmail";
            this.lnkAuthorEmail.Size = new System.Drawing.Size(25, 12);
            this.lnkAuthorEmail.TabIndex = 7;
            this.lnkAuthorEmail.TabStop = true;
            this.lnkAuthorEmail.Text = "Sict";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "技术支持:";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(243, 270);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(66, 12);
            this.lblCopyright.TabIndex = 9;
            this.lblCopyright.Text = "<Copyright>";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(244, 43);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(397, 19);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "<Description>";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(244, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(403, 19);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "<Application Name>";
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(244, 23);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(407, 19);
            this.lblVersion.TabIndex = 14;
            this.lblVersion.Text = "<Version>";
            // 
            // AboutMeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 340);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lnkAuthorEmail);
            this.Controls.Add(this.lnkHomePage);
            this.Controls.Add(this.rtbHelp);
            this.Controls.Add(this.assembliesListView);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutMeFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关于";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView assembliesListView;
        private System.Windows.Forms.ColumnHeader assemblyColumnHeader;
        private System.Windows.Forms.ColumnHeader versionColumnHeader;
        private System.Windows.Forms.ColumnHeader dateColumnHeader;
        private System.Windows.Forms.RichTextBox rtbHelp;
        private System.Windows.Forms.LinkLabel lnkHomePage;
        private System.Windows.Forms.ColumnHeader companyNameColumnHeader;
        private System.Windows.Forms.ColumnHeader descriptionColumnHeader;
        private System.Windows.Forms.LinkLabel lnkAuthorEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblVersion;
    }
}