namespace TestGas
{
    partial class TestGasFrm
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
            this.tvOption = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvOption
            // 
            this.tvOption.Location = new System.Drawing.Point(5, 7);
            this.tvOption.Name = "tvOption";
            this.tvOption.Size = new System.Drawing.Size(133, 280);
            this.tvOption.TabIndex = 44;
            // 
            // TestGasFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 296);
            this.Controls.Add(this.tvOption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestGasFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestGas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvOption;
    }
}

