namespace ChromatoCore.sample
{
    partial class SampleReportViewer
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
            this.printBar = new ChromatoPrint.PrintExtBar();
            this.SuspendLayout();
            // 
            // printBar
            // 
            this.printBar.Document = null;
            this.printBar.Location = new System.Drawing.Point(0, 0);
            this.printBar.Name = "printBar";
            this.printBar.PreviewControl = null;
            this.printBar.PrintMngUser = null;
            this.printBar.Size = new System.Drawing.Size(516, 25);
            this.printBar.TabIndex = 4;
            this.printBar.Text = "printExtBar1";
            this.printBar.Zoom = 0;
            // 
            // SampleReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.printBar);
            this.Name = "SampleReportViewer";
            this.Size = new System.Drawing.Size(516, 185);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChromatoPrint.PrintExtBar printBar;


    }
}
