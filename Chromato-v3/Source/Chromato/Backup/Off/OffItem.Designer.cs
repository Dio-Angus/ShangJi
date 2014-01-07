namespace ChromatoCore.Off
{
    partial class OffItem
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
            this.components = new System.ComponentModel.Container();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.Result = new System.Windows.Forms.TabPage();
            this.Export = new System.Windows.Forms.TabPage();
            this.Config = new System.Windows.Forms.TabPage();
            this.imagelistMain = new System.Windows.Forms.ImageList(this.components);
            this.tbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbMain.Controls.Add(this.Result);
            this.tbMain.Controls.Add(this.Export);
            this.tbMain.Controls.Add(this.Config);
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbMain.HotTrack = true;
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(394, 27);
            this.tbMain.TabIndex = 11;
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(4, 24);
            this.Result.Name = "Result";
            this.Result.Padding = new System.Windows.Forms.Padding(3);
            this.Result.Size = new System.Drawing.Size(386, 0);
            this.Result.TabIndex = 1;
            this.Result.Tag = "Result";
            this.Result.Text = "结果";
            this.Result.UseVisualStyleBackColor = true;
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(4, 24);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(386, 0);
            this.Export.TabIndex = 2;
            this.Export.Tag = "Export";
            this.Export.Text = "导出";
            this.Export.UseVisualStyleBackColor = true;
            // 
            // Config
            // 
            this.Config.Location = new System.Drawing.Point(4, 24);
            this.Config.Name = "Config";
            this.Config.Size = new System.Drawing.Size(386, 0);
            this.Config.TabIndex = 3;
            this.Config.Tag = "Config";
            this.Config.Text = "配置";
            this.Config.UseVisualStyleBackColor = true;
            // 
            // imagelistMain
            // 
            this.imagelistMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imagelistMain.ImageSize = new System.Drawing.Size(16, 16);
            this.imagelistMain.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // OffItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbMain);
            this.Name = "OffItem";
            this.Size = new System.Drawing.Size(394, 135);
            this.tbMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage Result;
        private System.Windows.Forms.TabPage Export;
        private System.Windows.Forms.TabPage Config;
        private System.Windows.Forms.ImageList imagelistMain;
    }
}
