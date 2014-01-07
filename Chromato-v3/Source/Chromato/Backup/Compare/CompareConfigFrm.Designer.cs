namespace ChromatoCore.Compare
{
    partial class CompareConfigFrm
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
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtShowMaxX = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtShowMinX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtShowMinY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtShowMaxY = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbConfig = new System.Windows.Forms.GroupBox();
            this.gbConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 62;
            this.label6.Text = "右限：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(305, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 63;
            this.label11.Text = "分钟";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(189, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 60;
            this.label12.Text = "左限：";
            // 
            // txtShowMaxX
            // 
            this.txtShowMaxX.Location = new System.Drawing.Point(227, 42);
            this.txtShowMaxX.MaxLength = 8;
            this.txtShowMaxX.Name = "txtShowMaxX";
            this.txtShowMaxX.Size = new System.Drawing.Size(72, 19);
            this.txtShowMaxX.TabIndex = 65;
            this.txtShowMaxX.Text = "-3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(305, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 61;
            this.label13.Text = "分钟";
            // 
            // txtShowMinX
            // 
            this.txtShowMinX.Location = new System.Drawing.Point(227, 21);
            this.txtShowMinX.MaxLength = 8;
            this.txtShowMinX.Name = "txtShowMinX";
            this.txtShowMinX.Size = new System.Drawing.Size(72, 19);
            this.txtShowMinX.TabIndex = 64;
            this.txtShowMinX.Text = "3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 56;
            this.label10.Text = "下限：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(129, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 57;
            this.label9.Text = "毫伏";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 54;
            this.label3.Text = "上限：";
            // 
            // txtShowMinY
            // 
            this.txtShowMinY.Location = new System.Drawing.Point(55, 40);
            this.txtShowMinY.MaxLength = 8;
            this.txtShowMinY.Name = "txtShowMinY";
            this.txtShowMinY.Size = new System.Drawing.Size(72, 19);
            this.txtShowMinY.TabIndex = 59;
            this.txtShowMinY.Text = "-3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 55;
            this.label4.Text = "毫伏";
            // 
            // txtShowMaxY
            // 
            this.txtShowMaxY.Location = new System.Drawing.Point(55, 18);
            this.txtShowMaxY.MaxLength = 8;
            this.txtShowMaxY.Name = "txtShowMaxY";
            this.txtShowMaxY.Size = new System.Drawing.Size(72, 19);
            this.txtShowMaxY.TabIndex = 58;
            this.txtShowMaxY.Text = "3";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(288, 85);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(67, 25);
            this.btnOK.TabIndex = 66;
            this.btnOK.Text = "确 定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // gbConfig
            // 
            this.gbConfig.Controls.Add(this.label9);
            this.gbConfig.Controls.Add(this.txtShowMaxY);
            this.gbConfig.Controls.Add(this.label11);
            this.gbConfig.Controls.Add(this.label4);
            this.gbConfig.Controls.Add(this.txtShowMaxX);
            this.gbConfig.Controls.Add(this.txtShowMinY);
            this.gbConfig.Controls.Add(this.label13);
            this.gbConfig.Controls.Add(this.txtShowMinX);
            this.gbConfig.Location = new System.Drawing.Point(3, 6);
            this.gbConfig.Name = "gbConfig";
            this.gbConfig.Size = new System.Drawing.Size(352, 74);
            this.gbConfig.TabIndex = 67;
            this.gbConfig.TabStop = false;
            this.gbConfig.Text = "显示";
            // 
            // CompareConfigFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 112);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompareConfigFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置窗口";
            this.gbConfig.ResumeLayout(false);
            this.gbConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtShowMaxX;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtShowMinX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtShowMinY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtShowMaxY;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox gbConfig;
    }
}