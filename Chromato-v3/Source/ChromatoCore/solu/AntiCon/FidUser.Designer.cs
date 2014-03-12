namespace ChromatoCore.solu.AntiCon
{
    partial class FidUser
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
            this.lb12 = new System.Windows.Forms.Label();
            this.lb11 = new System.Windows.Forms.Label();
            this.txtAlertTemp1 = new System.Windows.Forms.TextBox();
            this.txtInitTemp1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxPolarityFid1 = new System.Windows.Forms.CheckBox();
            this.cmbMagnifyFactorFid1 = new System.Windows.Forms.ComboBox();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.cmbMagnifyFactorFid2 = new System.Windows.Forms.ComboBox();
            this.lb21 = new System.Windows.Forms.Label();
            this.cbxPolarityFid2 = new System.Windows.Forms.CheckBox();
            this.lb22 = new System.Windows.Forms.Label();
            this.gb3 = new System.Windows.Forms.GroupBox();
            this.cmbMagnifyFactorFid3 = new System.Windows.Forms.ComboBox();
            this.lb31 = new System.Windows.Forms.Label();
            this.cbxPolarityFid3 = new System.Windows.Forms.CheckBox();
            this.lb32 = new System.Windows.Forms.Label();
            this.txtECDCapacity = new System.Windows.Forms.TextBox();
            this.txtECDCurrent = new System.Windows.Forms.TextBox();
            this.gb1.SuspendLayout();
            this.gb2.SuspendLayout();
            this.gb3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb12
            // 
            this.lb12.AutoSize = true;
            this.lb12.Location = new System.Drawing.Point(23, 35);
            this.lb12.Name = "lb12";
            this.lb12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb12.Size = new System.Drawing.Size(41, 12);
            this.lb12.TabIndex = 80;
            this.lb12.Text = "极性：";
            this.lb12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb11
            // 
            this.lb11.AutoSize = true;
            this.lb11.Location = new System.Drawing.Point(23, 17);
            this.lb11.Name = "lb11";
            this.lb11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb11.Size = new System.Drawing.Size(65, 12);
            this.lb11.TabIndex = 79;
            this.lb11.Text = "放大倍数：";
            this.lb11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAlertTemp1
            // 
            this.txtAlertTemp1.Location = new System.Drawing.Point(275, 12);
            this.txtAlertTemp1.Name = "txtAlertTemp1";
            this.txtAlertTemp1.Size = new System.Drawing.Size(78, 21);
            this.txtAlertTemp1.TabIndex = 2;
            // 
            // txtInitTemp1
            // 
            this.txtInitTemp1.Location = new System.Drawing.Point(119, 12);
            this.txtInitTemp1.Name = "txtInitTemp1";
            this.txtInitTemp1.Size = new System.Drawing.Size(78, 21);
            this.txtInitTemp1.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(204, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 76;
            this.label14.Text = "报警温度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 75;
            this.label3.Text = "初   温：";
            // 
            // cbxPolarityFid1
            // 
            this.cbxPolarityFid1.AutoSize = true;
            this.cbxPolarityFid1.Location = new System.Drawing.Point(99, 35);
            this.cbxPolarityFid1.Name = "cbxPolarityFid1";
            this.cbxPolarityFid1.Size = new System.Drawing.Size(37, 16);
            this.cbxPolarityFid1.TabIndex = 4;
            this.cbxPolarityFid1.Text = "负";
            this.cbxPolarityFid1.UseVisualStyleBackColor = true;
            this.cbxPolarityFid1.CheckedChanged += new System.EventHandler(this.cbxPolarityFid1_CheckedChanged);
            // 
            // cmbMagnifyFactorFid1
            // 
            this.cmbMagnifyFactorFid1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMagnifyFactorFid1.FormattingEnabled = true;
            this.cmbMagnifyFactorFid1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cmbMagnifyFactorFid1.Location = new System.Drawing.Point(99, 12);
            this.cmbMagnifyFactorFid1.Name = "cmbMagnifyFactorFid1";
            this.cmbMagnifyFactorFid1.Size = new System.Drawing.Size(234, 20);
            this.cmbMagnifyFactorFid1.TabIndex = 3;
            this.cmbMagnifyFactorFid1.SelectedIndexChanged += new System.EventHandler(this.cmbMagnifyFactorFid1_SelectedIndexChanged);
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.cmbMagnifyFactorFid1);
            this.gb1.Controls.Add(this.lb11);
            this.gb1.Controls.Add(this.cbxPolarityFid1);
            this.gb1.Controls.Add(this.lb12);
            this.gb1.Location = new System.Drawing.Point(19, 39);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(357, 56);
            this.gb1.TabIndex = 3;
            this.gb1.TabStop = false;
            this.gb1.Text = "FID1";
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.cmbMagnifyFactorFid2);
            this.gb2.Controls.Add(this.lb21);
            this.gb2.Controls.Add(this.cbxPolarityFid2);
            this.gb2.Controls.Add(this.lb22);
            this.gb2.Location = new System.Drawing.Point(19, 98);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(357, 53);
            this.gb2.TabIndex = 3;
            this.gb2.TabStop = false;
            this.gb2.Text = "ECD";
            // 
            // cmbMagnifyFactorFid2
            // 
            this.cmbMagnifyFactorFid2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMagnifyFactorFid2.FormattingEnabled = true;
            this.cmbMagnifyFactorFid2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cmbMagnifyFactorFid2.Location = new System.Drawing.Point(99, 12);
            this.cmbMagnifyFactorFid2.Name = "cmbMagnifyFactorFid2";
            this.cmbMagnifyFactorFid2.Size = new System.Drawing.Size(234, 20);
            this.cmbMagnifyFactorFid2.TabIndex = 3;
            this.cmbMagnifyFactorFid2.SelectedIndexChanged += new System.EventHandler(this.cmbMagnifyFactorFid1_SelectedIndexChanged);
            // 
            // lb21
            // 
            this.lb21.AutoSize = true;
            this.lb21.Location = new System.Drawing.Point(23, 17);
            this.lb21.Name = "lb21";
            this.lb21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb21.Size = new System.Drawing.Size(65, 12);
            this.lb21.TabIndex = 79;
            this.lb21.Text = "放大倍数：";
            this.lb21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxPolarityFid2
            // 
            this.cbxPolarityFid2.AutoSize = true;
            this.cbxPolarityFid2.Location = new System.Drawing.Point(99, 35);
            this.cbxPolarityFid2.Name = "cbxPolarityFid2";
            this.cbxPolarityFid2.Size = new System.Drawing.Size(37, 16);
            this.cbxPolarityFid2.TabIndex = 4;
            this.cbxPolarityFid2.Text = "负";
            this.cbxPolarityFid2.UseVisualStyleBackColor = true;
            this.cbxPolarityFid2.CheckedChanged += new System.EventHandler(this.cbxPolarityFid1_CheckedChanged);
            // 
            // lb22
            // 
            this.lb22.AutoSize = true;
            this.lb22.Location = new System.Drawing.Point(23, 36);
            this.lb22.Name = "lb22";
            this.lb22.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb22.Size = new System.Drawing.Size(41, 12);
            this.lb22.TabIndex = 80;
            this.lb22.Text = "极性：";
            this.lb22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gb3
            // 
            this.gb3.Controls.Add(this.cmbMagnifyFactorFid3);
            this.gb3.Controls.Add(this.lb31);
            this.gb3.Controls.Add(this.cbxPolarityFid3);
            this.gb3.Controls.Add(this.lb32);
            this.gb3.Location = new System.Drawing.Point(19, 157);
            this.gb3.Name = "gb3";
            this.gb3.Size = new System.Drawing.Size(357, 53);
            this.gb3.TabIndex = 3;
            this.gb3.TabStop = false;
            this.gb3.Text = "FPD";
            // 
            // cmbMagnifyFactorFid3
            // 
            this.cmbMagnifyFactorFid3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMagnifyFactorFid3.FormattingEnabled = true;
            this.cmbMagnifyFactorFid3.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cmbMagnifyFactorFid3.Location = new System.Drawing.Point(99, 12);
            this.cmbMagnifyFactorFid3.Name = "cmbMagnifyFactorFid3";
            this.cmbMagnifyFactorFid3.Size = new System.Drawing.Size(234, 20);
            this.cmbMagnifyFactorFid3.TabIndex = 3;
            this.cmbMagnifyFactorFid3.SelectedIndexChanged += new System.EventHandler(this.cmbMagnifyFactorFid1_SelectedIndexChanged);
            // 
            // lb31
            // 
            this.lb31.AutoSize = true;
            this.lb31.Location = new System.Drawing.Point(23, 17);
            this.lb31.Name = "lb31";
            this.lb31.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb31.Size = new System.Drawing.Size(65, 12);
            this.lb31.TabIndex = 79;
            this.lb31.Text = "放大倍数：";
            this.lb31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxPolarityFid3
            // 
            this.cbxPolarityFid3.AutoSize = true;
            this.cbxPolarityFid3.Location = new System.Drawing.Point(99, 35);
            this.cbxPolarityFid3.Name = "cbxPolarityFid3";
            this.cbxPolarityFid3.Size = new System.Drawing.Size(37, 16);
            this.cbxPolarityFid3.TabIndex = 4;
            this.cbxPolarityFid3.Text = "负";
            this.cbxPolarityFid3.UseVisualStyleBackColor = true;
            this.cbxPolarityFid3.CheckedChanged += new System.EventHandler(this.cbxPolarityFid1_CheckedChanged);
            // 
            // lb32
            // 
            this.lb32.AutoSize = true;
            this.lb32.Location = new System.Drawing.Point(23, 36);
            this.lb32.Name = "lb32";
            this.lb32.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb32.Size = new System.Drawing.Size(41, 12);
            this.lb32.TabIndex = 80;
            this.lb32.Text = "极性：";
            this.lb32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtECDCapacity
            // 
            this.txtECDCapacity.Location = new System.Drawing.Point(44, 216);
            this.txtECDCapacity.Name = "txtECDCapacity";
            this.txtECDCapacity.Size = new System.Drawing.Size(234, 21);
            this.txtECDCapacity.TabIndex = 1;
            this.txtECDCapacity.Visible = false;
            // 
            // txtECDCurrent
            // 
            this.txtECDCurrent.Location = new System.Drawing.Point(44, 235);
            this.txtECDCurrent.Name = "txtECDCurrent";
            this.txtECDCurrent.Size = new System.Drawing.Size(234, 21);
            this.txtECDCurrent.TabIndex = 1;
            this.txtECDCurrent.Visible = false;
            // 
            // FidUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb3);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.txtAlertTemp1);
            this.Controls.Add(this.txtECDCurrent);
            this.Controls.Add(this.txtECDCapacity);
            this.Controls.Add(this.txtInitTemp1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label14);
            this.Name = "FidUser";
            this.Size = new System.Drawing.Size(385, 270);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            this.gb3.ResumeLayout(false);
            this.gb3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb12;
        private System.Windows.Forms.Label lb11;
        private System.Windows.Forms.TextBox txtAlertTemp1;
        private System.Windows.Forms.TextBox txtInitTemp1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbxPolarityFid1;
        private System.Windows.Forms.ComboBox cmbMagnifyFactorFid1;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.ComboBox cmbMagnifyFactorFid2;
        private System.Windows.Forms.Label lb21;
        private System.Windows.Forms.CheckBox cbxPolarityFid2;
        private System.Windows.Forms.Label lb22;
        private System.Windows.Forms.GroupBox gb3;
        private System.Windows.Forms.ComboBox cmbMagnifyFactorFid3;
        private System.Windows.Forms.Label lb31;
        private System.Windows.Forms.CheckBox cbxPolarityFid3;
        private System.Windows.Forms.Label lb32;
        private System.Windows.Forms.TextBox txtECDCapacity;
        private System.Windows.Forms.TextBox txtECDCurrent;

    }
}
