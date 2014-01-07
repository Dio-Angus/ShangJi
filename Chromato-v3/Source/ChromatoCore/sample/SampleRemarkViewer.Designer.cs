namespace ChromatoCore.sample
{
    partial class SampleRemarkViewer
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
            this.rtbRemark = new System.Windows.Forms.RichTextBox();
            this.gbRemark = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbRemark.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbRemark
            // 
            this.rtbRemark.BackColor = System.Drawing.SystemColors.Info;
            this.rtbRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbRemark.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbRemark.ImeMode = System.Windows.Forms.ImeMode.On;
            this.rtbRemark.Location = new System.Drawing.Point(3, 17);
            this.rtbRemark.MaxLength = 512;
            this.rtbRemark.Name = "rtbRemark";
            this.rtbRemark.Size = new System.Drawing.Size(532, 253);
            this.rtbRemark.TabIndex = 0;
            this.rtbRemark.Text = "";
            // 
            // gbRemark
            // 
            this.gbRemark.Controls.Add(this.rtbRemark);
            this.gbRemark.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRemark.Location = new System.Drawing.Point(0, 0);
            this.gbRemark.Name = "gbRemark";
            this.gbRemark.Size = new System.Drawing.Size(538, 273);
            this.gbRemark.TabIndex = 1;
            this.gbRemark.TabStop = false;
            this.gbRemark.Text = "备注信息";
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(5, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保    存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SampleRemarkViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbRemark);
            this.Name = "SampleRemarkViewer";
            this.Size = new System.Drawing.Size(538, 312);
            this.gbRemark.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbRemark;
        private System.Windows.Forms.GroupBox gbRemark;
        private System.Windows.Forms.Button btnSave;
    }
}
