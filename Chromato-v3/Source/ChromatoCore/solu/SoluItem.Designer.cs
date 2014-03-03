namespace ChromatoCore.solu
{
    partial class SoluItem
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
            this.SamplePara = new System.Windows.Forms.TabPage();
            this.AnalyPara = new System.Windows.Forms.TabPage();
            this.TimeProc = new System.Windows.Forms.TabPage();
            this.IdTable = new System.Windows.Forms.TabPage();
            this.AntiMethod = new System.Windows.Forms.TabPage();
            this.Remark = new System.Windows.Forms.TabPage();
            this.tbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbMain.Controls.Add(this.Info);
            this.tbMain.Controls.Add(this.SamplePara);
            this.tbMain.Controls.Add(this.AnalyPara);
            this.tbMain.Controls.Add(this.TimeProc);
            this.tbMain.Controls.Add(this.IdTable);
            this.tbMain.Controls.Add(this.AntiMethod);
            this.tbMain.Controls.Add(this.Remark);
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(743, 27);
            this.tbMain.TabIndex = 4;
            // 
            // Info
            // 
            this.Info.Location = new System.Drawing.Point(4, 25);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(735, 0);
            this.Info.TabIndex = 4;
            this.Info.Tag = "Info";
            this.Info.Text = "信息";
            this.Info.UseVisualStyleBackColor = true;
            // 
            // SamplePara
            // 
            this.SamplePara.Location = new System.Drawing.Point(4, 25);
            this.SamplePara.Name = "SamplePara";
            this.SamplePara.Size = new System.Drawing.Size(467, 0);
            this.SamplePara.TabIndex = 5;
            this.SamplePara.Tag = "SamplePara";
            this.SamplePara.Text = "采集";
            this.SamplePara.UseVisualStyleBackColor = true;
            // 
            // AnalyPara
            // 
            this.AnalyPara.Location = new System.Drawing.Point(4, 25);
            this.AnalyPara.Name = "AnalyPara";
            this.AnalyPara.Size = new System.Drawing.Size(467, 0);
            this.AnalyPara.TabIndex = 6;
            this.AnalyPara.Tag = "AnalyPara";
            this.AnalyPara.Text = "分析";
            this.AnalyPara.UseVisualStyleBackColor = true;
            // 
            // TimeProc
            // 
            this.TimeProc.Location = new System.Drawing.Point(4, 25);
            this.TimeProc.Name = "TimeProc";
            this.TimeProc.Size = new System.Drawing.Size(467, 0);
            this.TimeProc.TabIndex = 7;
            this.TimeProc.Tag = "TimeProc";
            this.TimeProc.Text = "时间程序";
            this.TimeProc.UseVisualStyleBackColor = true;
            // 
            // IdTable
            // 
            this.IdTable.Location = new System.Drawing.Point(4, 25);
            this.IdTable.Name = "IdTable";
            this.IdTable.Size = new System.Drawing.Size(467, 0);
            this.IdTable.TabIndex = 8;
            this.IdTable.Tag = "IdTable";
            this.IdTable.Text = "峰类鉴别表";
            this.IdTable.UseVisualStyleBackColor = true;
            // 
            // AntiMethod
            // 
            this.AntiMethod.Location = new System.Drawing.Point(4, 25);
            this.AntiMethod.Name = "AntiMethod";
            this.AntiMethod.Size = new System.Drawing.Size(467, 0);
            this.AntiMethod.TabIndex = 9;
            this.AntiMethod.Tag = "AntiMethod";
            this.AntiMethod.Text = "反控";
            this.AntiMethod.UseVisualStyleBackColor = true;
            // 
            // Remark
            // 
            this.Remark.Location = new System.Drawing.Point(4, 25);
            this.Remark.Name = "Remark";
            this.Remark.Size = new System.Drawing.Size(467, 0);
            this.Remark.TabIndex = 10;
            this.Remark.Tag = "Remark";
            this.Remark.Text = "备注";
            this.Remark.UseVisualStyleBackColor = true;
            // 
            // SoluItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbMain);
            this.Name = "SoluItem";
            this.Size = new System.Drawing.Size(743, 279);
            this.tbMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage Info;
        private System.Windows.Forms.TabPage SamplePara;
        private System.Windows.Forms.TabPage AnalyPara;
        private System.Windows.Forms.TabPage TimeProc;
        private System.Windows.Forms.TabPage IdTable;
        private System.Windows.Forms.TabPage AntiMethod;
        private System.Windows.Forms.TabPage Remark;
    }
}
