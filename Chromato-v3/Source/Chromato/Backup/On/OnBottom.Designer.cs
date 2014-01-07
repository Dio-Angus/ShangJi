namespace ChromatoCore.On
{
    partial class OnBottom
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
            this.RealPlot = new System.Windows.Forms.TabPage();
            this.HardStatus = new System.Windows.Forms.TabPage();
            this.tbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbMain.Controls.Add(this.RealPlot);
            this.tbMain.Controls.Add(this.HardStatus);
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(759, 27);
            this.tbMain.TabIndex = 6;
            // 
            // RealPlot
            // 
            this.RealPlot.Location = new System.Drawing.Point(4, 24);
            this.RealPlot.Name = "RealPlot";
            this.RealPlot.Size = new System.Drawing.Size(751, 0);
            this.RealPlot.TabIndex = 7;
            this.RealPlot.Tag = "RealPlot";
            this.RealPlot.Text = "实时绘图";
            this.RealPlot.UseVisualStyleBackColor = true;
            // 
            // HardStatus
            // 
            this.HardStatus.Location = new System.Drawing.Point(4, 24);
            this.HardStatus.Name = "HardStatus";
            this.HardStatus.Size = new System.Drawing.Size(751, 0);
            this.HardStatus.TabIndex = 6;
            this.HardStatus.Tag = "HardStatus";
            this.HardStatus.Text = "设备状态";
            this.HardStatus.UseVisualStyleBackColor = true;
            // 
            // OnBottom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbMain);
            this.DoubleBuffered = true;
            this.Name = "OnBottom";
            this.Size = new System.Drawing.Size(759, 179);
            this.tbMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage HardStatus;
        private System.Windows.Forms.TabPage RealPlot;
    }
}
