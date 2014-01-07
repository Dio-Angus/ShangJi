namespace ChromatoCore.solu.IdT
{
    partial class SizeDensityFrm
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
            this.gbGraph = new System.Windows.Forms.GroupBox();
            this.tsSizeDensity = new System.Windows.Forms.ToolStrip();
            this.tsBtnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSizeDensity.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGraph
            // 
            this.gbGraph.Location = new System.Drawing.Point(3, 29);
            this.gbGraph.Name = "gbGraph";
            this.gbGraph.Size = new System.Drawing.Size(530, 270);
            this.gbGraph.TabIndex = 0;
            this.gbGraph.TabStop = false;
            this.gbGraph.Text = "校正曲线";
            // 
            // tsSizeDensity
            // 
            this.tsSizeDensity.BackColor = System.Drawing.SystemColors.Control;
            this.tsSizeDensity.Dock = System.Windows.Forms.DockStyle.None;
            this.tsSizeDensity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnClose,
            this.toolStripSeparator1});
            this.tsSizeDensity.Location = new System.Drawing.Point(3, 4);
            this.tsSizeDensity.Name = "tsSizeDensity";
            this.tsSizeDensity.Size = new System.Drawing.Size(70, 25);
            this.tsSizeDensity.TabIndex = 7;
            this.tsSizeDensity.Text = "toolStrip1";
            // 
            // tsBtnClose
            // 
            this.tsBtnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnClose.Image = global::ChromatoCore.Properties.Resources.Exit;
            this.tsBtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnClose.Name = "tsBtnClose";
            this.tsBtnClose.Size = new System.Drawing.Size(23, 22);
            this.tsBtnClose.Text = "关闭";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // SizeDensityFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 300);
            this.ControlBox = false;
            this.Controls.Add(this.gbGraph);
            this.Controls.Add(this.tsSizeDensity);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SizeDensityFrm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "面积浓度图形";
            this.Resize += new System.EventHandler(this.SizeDensityFrm_Resize);
            this.tsSizeDensity.ResumeLayout(false);
            this.tsSizeDensity.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGraph;
        private System.Windows.Forms.ToolStrip tsSizeDensity;
        private System.Windows.Forms.ToolStripButton tsBtnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}