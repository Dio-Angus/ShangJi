namespace ChromatoCore.solu.sUi
{
    partial class ArithParaUi
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
            this.gbMeasurePara = new System.Windows.Forms.GroupBox();
            this.rbHeight = new System.Windows.Forms.RadioButton();
            this.rbArea = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbMeasurePara.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMeasurePara
            // 
            this.gbMeasurePara.Controls.Add(this.rbHeight);
            this.gbMeasurePara.Controls.Add(this.rbArea);
            this.gbMeasurePara.Location = new System.Drawing.Point(10, 12);
            this.gbMeasurePara.Name = "gbMeasurePara";
            this.gbMeasurePara.Size = new System.Drawing.Size(188, 55);
            this.gbMeasurePara.TabIndex = 34;
            this.gbMeasurePara.TabStop = false;
            this.gbMeasurePara.Text = "定量参数";
            // 
            // rbHeight
            // 
            this.rbHeight.AutoSize = true;
            this.rbHeight.Location = new System.Drawing.Point(101, 23);
            this.rbHeight.Name = "rbHeight";
            this.rbHeight.Size = new System.Drawing.Size(47, 16);
            this.rbHeight.TabIndex = 1;
            this.rbHeight.TabStop = true;
            this.rbHeight.Text = "高度";
            this.rbHeight.UseVisualStyleBackColor = true;
            // 
            // rbArea
            // 
            this.rbArea.AutoSize = true;
            this.rbArea.Location = new System.Drawing.Point(8, 23);
            this.rbArea.Name = "rbArea";
            this.rbArea.Size = new System.Drawing.Size(47, 16);
            this.rbArea.TabIndex = 0;
            this.rbArea.TabStop = true;
            this.rbArea.Text = "面积";
            this.rbArea.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(224, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 25);
            this.btnOK.TabIndex = 35;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ArithParaUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 85);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbMeasurePara);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArithParaUi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更改计算方法的响应参数";
            this.gbMeasurePara.ResumeLayout(false);
            this.gbMeasurePara.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMeasurePara;
        private System.Windows.Forms.RadioButton rbHeight;
        private System.Windows.Forms.RadioButton rbArea;
        private System.Windows.Forms.Button btnOK;
    }
}