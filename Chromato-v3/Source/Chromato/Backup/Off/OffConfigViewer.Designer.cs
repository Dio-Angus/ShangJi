namespace ChromatoCore.Off
{
    partial class OffConfigViewer
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gbConfig = new System.Windows.Forms.GroupBox();
            this.cbxShowMarker = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtShowMaxX = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtShowMinX = new System.Windows.Forms.TextBox();
            this.cbxAutoScale = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtShowMinY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtShowMaxY = new System.Windows.Forms.TextBox();
            this.cbxIsMoveBlank = new System.Windows.Forms.CheckBox();
            this.cmbSolution = new System.Windows.Forms.ComboBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtSampleName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConfig
            // 
            this.gbConfig.Controls.Add(this.cbxShowMarker);
            this.gbConfig.Controls.Add(this.label6);
            this.gbConfig.Controls.Add(this.label11);
            this.gbConfig.Controls.Add(this.label12);
            this.gbConfig.Controls.Add(this.txtShowMaxX);
            this.gbConfig.Controls.Add(this.label13);
            this.gbConfig.Controls.Add(this.txtShowMinX);
            this.gbConfig.Controls.Add(this.cbxAutoScale);
            this.gbConfig.Controls.Add(this.label10);
            this.gbConfig.Controls.Add(this.label9);
            this.gbConfig.Controls.Add(this.label3);
            this.gbConfig.Controls.Add(this.txtShowMinY);
            this.gbConfig.Controls.Add(this.label4);
            this.gbConfig.Controls.Add(this.txtShowMaxY);
            this.gbConfig.Controls.Add(this.cbxIsMoveBlank);
            this.gbConfig.Controls.Add(this.cmbSolution);
            this.gbConfig.Controls.Add(this.txtStatus);
            this.gbConfig.Controls.Add(this.txtSampleName);
            this.gbConfig.Controls.Add(this.label2);
            this.gbConfig.Controls.Add(this.label7);
            this.gbConfig.Controls.Add(this.label8);
            this.gbConfig.Location = new System.Drawing.Point(3, 5);
            this.gbConfig.Name = "gbConfig";
            this.gbConfig.Size = new System.Drawing.Size(551, 225);
            this.gbConfig.TabIndex = 41;
            this.gbConfig.TabStop = false;
            this.gbConfig.Text = "详细信息";
            // 
            // cbxShowMarker
            // 
            this.cbxShowMarker.AutoSize = true;
            this.cbxShowMarker.Location = new System.Drawing.Point(91, 146);
            this.cbxShowMarker.Name = "cbxShowMarker";
            this.cbxShowMarker.Size = new System.Drawing.Size(84, 16);
            this.cbxShowMarker.TabIndex = 55;
            this.cbxShowMarker.Text = "显示趋势点";
            this.cbxShowMarker.UseVisualStyleBackColor = true;
            this.cbxShowMarker.CheckedChanged += new System.EventHandler(this.cbxShowMarker_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(152, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 50;
            this.label6.Text = "右限：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(254, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 12);
            this.label11.TabIndex = 51;
            this.label11.Text = "min";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(153, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 48;
            this.label12.Text = "左限：";
            // 
            // txtShowMaxX
            // 
            this.txtShowMaxX.Location = new System.Drawing.Point(198, 119);
            this.txtShowMaxX.Name = "txtShowMaxX";
            this.txtShowMaxX.Size = new System.Drawing.Size(50, 21);
            this.txtShowMaxX.TabIndex = 53;
            this.txtShowMaxX.Text = "-3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(254, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 12);
            this.label13.TabIndex = 49;
            this.label13.Text = "min";
            // 
            // txtShowMinX
            // 
            this.txtShowMinX.Location = new System.Drawing.Point(198, 98);
            this.txtShowMinX.Name = "txtShowMinX";
            this.txtShowMinX.Size = new System.Drawing.Size(50, 21);
            this.txtShowMinX.TabIndex = 52;
            this.txtShowMinX.Text = "3";
            // 
            // cbxAutoScale
            // 
            this.cbxAutoScale.AutoSize = true;
            this.cbxAutoScale.Location = new System.Drawing.Point(13, 146);
            this.cbxAutoScale.Name = "cbxAutoScale";
            this.cbxAutoScale.Size = new System.Drawing.Size(72, 16);
            this.cbxAutoScale.TabIndex = 47;
            this.cbxAutoScale.Text = "自动坐标";
            this.cbxAutoScale.UseVisualStyleBackColor = true;
            this.cbxAutoScale.CheckedChanged += new System.EventHandler(this.cbxAutoScale_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 42;
            this.label10.Text = "下  限：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(123, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 43;
            this.label9.Text = "mv";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 40;
            this.label3.Text = "上  限：";
            // 
            // txtShowMinY
            // 
            this.txtShowMinY.Location = new System.Drawing.Point(70, 119);
            this.txtShowMinY.Name = "txtShowMinY";
            this.txtShowMinY.Size = new System.Drawing.Size(47, 21);
            this.txtShowMinY.TabIndex = 45;
            this.txtShowMinY.Text = "-3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 41;
            this.label4.Text = "mv";
            // 
            // txtShowMaxY
            // 
            this.txtShowMaxY.Location = new System.Drawing.Point(70, 96);
            this.txtShowMaxY.Name = "txtShowMaxY";
            this.txtShowMaxY.Size = new System.Drawing.Size(47, 21);
            this.txtShowMaxY.TabIndex = 44;
            this.txtShowMaxY.Text = "3";
            // 
            // cbxIsMoveBlank
            // 
            this.cbxIsMoveBlank.AutoSize = true;
            this.cbxIsMoveBlank.Location = new System.Drawing.Point(205, 146);
            this.cbxIsMoveBlank.Name = "cbxIsMoveBlank";
            this.cbxIsMoveBlank.Size = new System.Drawing.Size(72, 16);
            this.cbxIsMoveBlank.TabIndex = 38;
            this.cbxIsMoveBlank.Text = "基线扣除";
            this.cbxIsMoveBlank.UseVisualStyleBackColor = true;
            this.cbxIsMoveBlank.CheckedChanged += new System.EventHandler(this.cbxIsMoveBlank_CheckedChanged);
            // 
            // cmbSolution
            // 
            this.cmbSolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSolution.FormattingEnabled = true;
            this.cmbSolution.Location = new System.Drawing.Point(70, 47);
            this.cmbSolution.Name = "cmbSolution";
            this.cmbSolution.Size = new System.Drawing.Size(207, 20);
            this.cmbSolution.TabIndex = 36;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Info;
            this.txtStatus.Location = new System.Drawing.Point(70, 70);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(207, 21);
            this.txtStatus.TabIndex = 3;
            // 
            // txtSampleName
            // 
            this.txtSampleName.BackColor = System.Drawing.SystemColors.Info;
            this.txtSampleName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSampleName.Location = new System.Drawing.Point(70, 22);
            this.txtSampleName.MaxLength = 100;
            this.txtSampleName.Name = "txtSampleName";
            this.txtSampleName.ReadOnly = true;
            this.txtSampleName.Size = new System.Drawing.Size(207, 21);
            this.txtSampleName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "样品名：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "状  态：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 35;
            this.label8.Text = "方案名：";
            // 
            // OffConfigViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbConfig);
            this.Name = "OffConfigViewer";
            this.Size = new System.Drawing.Size(564, 247);
            this.gbConfig.ResumeLayout(false);
            this.gbConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConfig;
        private System.Windows.Forms.ComboBox cmbSolution;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtSampleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbxIsMoveBlank;
        private System.Windows.Forms.CheckBox cbxAutoScale;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtShowMinY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtShowMaxY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtShowMaxX;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtShowMinX;
        private System.Windows.Forms.CheckBox cbxShowMarker;
    }
}
