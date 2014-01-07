namespace ChromatoCore.solu.Info
{
    partial class SoluInfoViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxUseTimeProc = new System.Windows.Forms.CheckBox();
            this.cmbAntiConName = new System.Windows.Forms.ComboBox();
            this.cmbTimeProcName = new System.Windows.Forms.ComboBox();
            this.cmbIdTableName = new System.Windows.Forms.ComboBox();
            this.cmbAnalyName = new System.Windows.Forms.ComboBox();
            this.cmbAcquName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSolutionName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 35;
            this.label8.Text = "ID  表  名：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "分析方法名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "方  案  名：";
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.label5);
            this.grpInfo.Controls.Add(this.cbxUseTimeProc);
            this.grpInfo.Controls.Add(this.cmbAntiConName);
            this.grpInfo.Controls.Add(this.cmbTimeProcName);
            this.grpInfo.Controls.Add(this.cmbIdTableName);
            this.grpInfo.Controls.Add(this.cmbAnalyName);
            this.grpInfo.Controls.Add(this.cmbAcquName);
            this.grpInfo.Controls.Add(this.label2);
            this.grpInfo.Controls.Add(this.txtSolutionName);
            this.grpInfo.Controls.Add(this.label4);
            this.grpInfo.Controls.Add(this.label3);
            this.grpInfo.Controls.Add(this.label7);
            this.grpInfo.Controls.Add(this.label1);
            this.grpInfo.Controls.Add(this.label8);
            this.grpInfo.Location = new System.Drawing.Point(3, 3);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(445, 210);
            this.grpInfo.TabIndex = 40;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "详细信息";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 47;
            this.label5.Text = "使用时间程序：";
            // 
            // cbxUseTimeProc
            // 
            this.cbxUseTimeProc.AutoSize = true;
            this.cbxUseTimeProc.Location = new System.Drawing.Point(132, 183);
            this.cbxUseTimeProc.Name = "cbxUseTimeProc";
            this.cbxUseTimeProc.Size = new System.Drawing.Size(15, 14);
            this.cbxUseTimeProc.TabIndex = 7;
            this.cbxUseTimeProc.UseVisualStyleBackColor = true;
            this.cbxUseTimeProc.Click += new System.EventHandler(this.cbxUseTimeProc_Click);
            // 
            // cmbAntiConName
            // 
            this.cmbAntiConName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAntiConName.FormattingEnabled = true;
            this.cmbAntiConName.Location = new System.Drawing.Point(132, 156);
            this.cmbAntiConName.Name = "cmbAntiConName";
            this.cmbAntiConName.Size = new System.Drawing.Size(296, 20);
            this.cmbAntiConName.TabIndex = 6;
            this.cmbAntiConName.SelectedIndexChanged += new System.EventHandler(this.cbxAntiConName_SelectedIndexChanged);
            // 
            // cmbTimeProcName
            // 
            this.cmbTimeProcName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeProcName.FormattingEnabled = true;
            this.cmbTimeProcName.Location = new System.Drawing.Point(132, 129);
            this.cmbTimeProcName.Name = "cmbTimeProcName";
            this.cmbTimeProcName.Size = new System.Drawing.Size(296, 20);
            this.cmbTimeProcName.TabIndex = 5;
            this.cmbTimeProcName.SelectedIndexChanged += new System.EventHandler(this.cbxTimeProcName_SelectedIndexChanged);
            // 
            // cmbIdTableName
            // 
            this.cmbIdTableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdTableName.FormattingEnabled = true;
            this.cmbIdTableName.Location = new System.Drawing.Point(132, 102);
            this.cmbIdTableName.Name = "cmbIdTableName";
            this.cmbIdTableName.Size = new System.Drawing.Size(296, 20);
            this.cmbIdTableName.TabIndex = 4;
            this.cmbIdTableName.SelectedIndexChanged += new System.EventHandler(this.cbxIdTableName_SelectedIndexChanged);
            // 
            // cmbAnalyName
            // 
            this.cmbAnalyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnalyName.FormattingEnabled = true;
            this.cmbAnalyName.Location = new System.Drawing.Point(132, 76);
            this.cmbAnalyName.Name = "cmbAnalyName";
            this.cmbAnalyName.Size = new System.Drawing.Size(296, 20);
            this.cmbAnalyName.TabIndex = 3;
            this.cmbAnalyName.SelectedIndexChanged += new System.EventHandler(this.cbxAnalyName_SelectedIndexChanged);
            // 
            // cmbAcquName
            // 
            this.cmbAcquName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAcquName.FormattingEnabled = true;
            this.cmbAcquName.Location = new System.Drawing.Point(132, 50);
            this.cmbAcquName.Name = "cmbAcquName";
            this.cmbAcquName.Size = new System.Drawing.Size(296, 20);
            this.cmbAcquName.TabIndex = 2;
            this.cmbAcquName.SelectedIndexChanged += new System.EventHandler(this.cbxAcquName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "采集方法名：";
            // 
            // txtSolutionName
            // 
            this.txtSolutionName.BackColor = System.Drawing.SystemColors.Info;
            this.txtSolutionName.Location = new System.Drawing.Point(132, 24);
            this.txtSolutionName.Name = "txtSolutionName";
            this.txtSolutionName.ReadOnly = true;
            this.txtSolutionName.Size = new System.Drawing.Size(296, 21);
            this.txtSolutionName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "反控方法名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "时间程序名：";
            // 
            // SoluInfoViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.grpInfo);
            this.Name = "SoluInfoViewer";
            this.Size = new System.Drawing.Size(476, 225);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSolutionName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAntiConName;
        private System.Windows.Forms.ComboBox cmbTimeProcName;
        private System.Windows.Forms.ComboBox cmbIdTableName;
        private System.Windows.Forms.ComboBox cmbAnalyName;
        private System.Windows.Forms.ComboBox cmbAcquName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbxUseTimeProc;
    }
}
