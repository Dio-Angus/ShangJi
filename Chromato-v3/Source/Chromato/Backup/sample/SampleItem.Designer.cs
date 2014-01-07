namespace ChromatoCore.sample
{
    partial class SampleItem
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
            this.tbMain = new System.Windows.Forms.TabControl();
            this.Info = new System.Windows.Forms.TabPage();
            this.Result = new System.Windows.Forms.TabPage();
            this.Report = new System.Windows.Forms.TabPage();
            this.Remark = new System.Windows.Forms.TabPage();
            this.tbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbMain.Controls.Add(this.Info);
            this.tbMain.Controls.Add(this.Result);
            this.tbMain.Controls.Add(this.Report);
            this.tbMain.Controls.Add(this.Remark);
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(275, 28);
            this.tbMain.TabIndex = 5;
            // 
            // Info
            // 
            this.Info.Location = new System.Drawing.Point(4, 24);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(267, 0);
            this.Info.TabIndex = 4;
            this.Info.Tag = "Info";
            this.Info.Text = "信息";
            this.Info.UseVisualStyleBackColor = true;
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(4, 24);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(267, 7);
            this.Result.TabIndex = 5;
            this.Result.Tag = "Result";
            this.Result.Text = "结果";
            this.Result.UseVisualStyleBackColor = true;
            // 
            // Report
            // 
            this.Report.Location = new System.Drawing.Point(4, 24);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(267, 7);
            this.Report.TabIndex = 6;
            this.Report.Tag = "Report";
            this.Report.Text = "报告";
            this.Report.UseVisualStyleBackColor = true;
            // 
            // Remark
            // 
            this.Remark.Location = new System.Drawing.Point(4, 24);
            this.Remark.Name = "Remark";
            this.Remark.Size = new System.Drawing.Size(267, 7);
            this.Remark.TabIndex = 7;
            this.Remark.Tag = "Remark";
            this.Remark.Text = "备注";
            this.Remark.UseVisualStyleBackColor = true;
            // 
            // SampleItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbMain);
            this.Name = "SampleItem";
            this.Size = new System.Drawing.Size(275, 178);
            this.tbMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage Info;
        private System.Windows.Forms.TabPage Result;
        private System.Windows.Forms.TabPage Report;
        private System.Windows.Forms.TabPage Remark;
    }
}
